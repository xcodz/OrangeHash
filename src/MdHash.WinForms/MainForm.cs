using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MdHash.Core.Framework.Abstractions;
using MdHash.Core.Framework.Algorithms;
using MdHash.Core.Framework.Services;
using System.Collections.Generic;
using System.Text;

namespace MdHash.WinForms
{
    public partial class MainForm : Form
    {
        private readonly string[] _args;
        private readonly IHashService _hashService = new StreamingHashService();
        private string _currentFilePath = string.Empty;
        private string _lastSavedFilePath = null;
        private readonly SettingsStore _settings = new SettingsStore();
        private bool _lastWasTextInput = false;

        public MainForm(string[] args)
        {
            _args = args ?? Array.Empty<string>();
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += MainForm_DragEnter;
            this.DragDrop += MainForm_DragDrop;
            this.txtStatus.Click += new System.EventHandler(this.txtStatus_Click);
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Load settings and apply UI state
            try
            {
                _settings.Load();
                chkMD5.Checked = _settings.MD5;
                chkSHA1.Checked = _settings.SHA1;
                chkSHA256.Checked = _settings.SHA256;
                chkSHA384.Checked = _settings.SHA384;
                chkSHA512.Checked = _settings.SHA512;
            }
            catch { /* ignore settings load issues */ }
            // A command-line argument is passed as the second argument. The first is the executable path.
            if (_args.Length > 1 && File.Exists(_args[1]))
            {
                await ProcessFileAsync(_args[1]);
            }
            else
            {
                SetStatus("Waiting for file...");
                lblFileName.Text = "Drag & drop a file here or click to select";
            }
        }

        private void SetStatus(string text, bool isLink = false, string linkPath = null)
        {
            txtStatus.Text = text;
            _lastSavedFilePath = linkPath;

            if (isLink && !string.IsNullOrEmpty(_lastSavedFilePath))
            {
                txtStatus.ForeColor = Color.Orange;
                txtStatus.Cursor = Cursors.Hand;
            }
            else
            {
                txtStatus.ForeColor = Color.DimGray;
                txtStatus.Cursor = Cursors.Default;
            }
        }

        private async Task ProcessFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                SetStatus("Error: File not found.");
                return;
            }

            _currentFilePath = filePath;
            _lastWasTextInput = false;
            lblFileName.Text = Path.GetFileName(filePath);
            txtHash.Text = txtHashSha1.Text = txtHashSha256.Text = string.Empty;
            if (txtHashSha384 != null) txtHashSha384.Text = string.Empty;
            if (txtHashSha512 != null) txtHashSha512.Text = string.Empty;
            pnlProgressFg.Width = 0;
            SetStatus("Working...");

            var progress = new Progress<double>(p => pnlProgressFg.Width = (int)(pnlProgressBg.ClientSize.Width * p));

            try
            {
                var selected = GetSelectedAlgorithms();
                var tasks = new List<Task>();
                bool progressAssigned = false;
                foreach (var item in selected)
                {
                    var prog = progressAssigned ? null : progress;
                    tasks.Add(ComputeHashAsync(filePath, item.kind, item.textBox, item.name, prog));
                    if (prog != null) progressAssigned = true;
                }
                // Put placeholders for algorithms not selected
                ShowUnselectedPlaceholders(selected.Select(s => s.kind));
                if (tasks.Count == 0)
                {
                    SetStatus("No algorithms selected");
                    return;
                }
                await Task.WhenAll(tasks);

                SetStatus("Ready");
            }
            catch (Exception ex)
            {
                SetStatus($"Error: {ex.Message}");
                pnlProgressFg.Width = 0;
            }
        }

        private async Task ComputeHashAsync(string path, HashAlgorithmKind kind, TextBox textBox, string kindName, IProgress<double> progress = null)
        {
            try
            {
                var hash = await _hashService.ComputeHashAsync(path, kind, progress);
                if (textBox.IsHandleCreated)
                {
                    textBox.Invoke((Action)(() => textBox.Text = hash));
                }
            }
            catch
            {
                if (textBox.IsHandleCreated)
                {
                    textBox.Invoke((Action)(() => textBox.Text = $"<{kindName} failed>"));
                }
            }
        }

        private List<(HashAlgorithmKind kind, TextBox textBox, string name)> GetSelectedAlgorithms()
        {
            var list = new List<(HashAlgorithmKind, TextBox, string)>();
            if (chkMD5.Checked) list.Add((HashAlgorithmKind.MD5, txtHash, "MD5"));
            if (chkSHA1.Checked) list.Add((HashAlgorithmKind.SHA1, txtHashSha1, "SHA-1"));
            if (chkSHA256.Checked) list.Add((HashAlgorithmKind.SHA256, txtHashSha256, "SHA-256"));
            if (chkSHA384.Checked) list.Add((HashAlgorithmKind.SHA384, txtHashSha384, "SHA-384"));
            if (chkSHA512.Checked) list.Add((HashAlgorithmKind.SHA512, txtHashSha512, "SHA-512"));
            return list;
        }

        private async Task ProcessTextAsync(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SetStatus("Enter text to hash");
                return;
            }

            txtHash.Text = txtHashSha1.Text = txtHashSha256.Text = string.Empty;
            if (txtHashSha384 != null) txtHashSha384.Text = string.Empty;
            if (txtHashSha512 != null) txtHashSha512.Text = string.Empty;
            pnlProgressFg.Width = pnlProgressBg.ClientSize.Width; // instant
            SetStatus("Working...");
            _lastWasTextInput = true;

            var selected = GetSelectedAlgorithms();
            var tasks = new List<Task>();
            foreach (var item in selected)
            {
                tasks.Add(ComputeHashForTextAsync(text, item.kind, item.textBox, item.name));
            }
            // Put placeholders for algorithms not selected
            ShowUnselectedPlaceholders(selected.Select(s => s.kind));
            if (tasks.Count == 0)
            {
                SetStatus("No algorithms selected");
                return;
            }
            try
            {
                await Task.WhenAll(tasks);
                SetStatus("Ready");
            }
            catch (Exception ex)
            {
                SetStatus($"Error: {ex.Message}");
            }
        }

        private void ShowUnselectedPlaceholders(IEnumerable<HashAlgorithmKind> selectedKinds)
        {
            var set = new HashSet<HashAlgorithmKind>(selectedKinds);
            foreach (var item in GetAllAlgorithmTextBoxes())
            {
                if (!set.Contains(item.kind))
                {
                    var msg = "Not selected";
                    if (item.textBox.IsHandleCreated)
                        item.textBox.Invoke((Action)(() => item.textBox.Text = msg));
                    else
                        item.textBox.Text = msg;
                }
            }
        }

        private List<(HashAlgorithmKind kind, TextBox textBox, string name)> GetAllAlgorithmTextBoxes()
        {
            return new List<(HashAlgorithmKind, TextBox, string)>
            {
                (HashAlgorithmKind.MD5, txtHash, "MD5"),
                (HashAlgorithmKind.SHA1, txtHashSha1, "SHA-1"),
                (HashAlgorithmKind.SHA256, txtHashSha256, "SHA-256"),
                (HashAlgorithmKind.SHA384, txtHashSha384, "SHA-384"),
                (HashAlgorithmKind.SHA512, txtHashSha512, "SHA-512"),
            };
        }

        private Task ComputeHashForTextAsync(string text, HashAlgorithmKind kind, TextBox textBox, string kindName)
        {
            return Task.Run(() =>
            {
                try
                {
                    var bytes = Encoding.UTF8.GetBytes(text);
                    using (var algorithm = CreateAlgorithm(kind))
                    {
                        var hashBytes = algorithm.ComputeHash(bytes);
                        var hash = ToLowerHex(hashBytes);
                        if (textBox.IsHandleCreated)
                        {
                            textBox.Invoke((Action)(() => textBox.Text = hash));
                        }
                    }
                }
                catch
                {
                    if (textBox.IsHandleCreated)
                    {
                        textBox.Invoke((Action)(() => textBox.Text = $"<{kindName} failed>"));
                    }
                }
            });
        }

        private static System.Security.Cryptography.HashAlgorithm CreateAlgorithm(HashAlgorithmKind kind)
        {
            switch (kind)
            {
                case HashAlgorithmKind.MD5: return System.Security.Cryptography.MD5.Create();
                case HashAlgorithmKind.SHA1: return System.Security.Cryptography.SHA1.Create();
                case HashAlgorithmKind.SHA256: return System.Security.Cryptography.SHA256.Create();
                case HashAlgorithmKind.SHA384:
                    try { return System.Security.Cryptography.SHA384Cng.Create(); } catch { }
                    return System.Security.Cryptography.SHA384.Create();
                case HashAlgorithmKind.SHA512:
                    try { return System.Security.Cryptography.SHA512Cng.Create(); } catch { }
                    return System.Security.Cryptography.SHA512.Create();
                default: throw new NotSupportedException("Unsupported algorithm: " + kind);
            }
        }

        private static string ToLowerHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToString("x2"));
            return sb.ToString();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private async void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                await ProcessFileAsync(files[0]);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;

            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                var pos = PointToClient(Cursor.Position);
                var ctl = GetChildAtPoint(pos);
                if (ctl == null || (ctl != txtHash && ctl != txtHashSha1 && ctl != txtHashSha256 && ctl != txtHashSha384 && ctl != txtHashSha512 && ctl != btnSave && ctl != btnClose && ctl != lblFileName))
                {
                    m.Result = (IntPtr)HTCAPTION;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string content = string.Empty;
                string outPath = null;
                if (_lastWasTextInput)
                {
                    using (var dlg = new SaveFileDialog())
                    {
                        dlg.Title = "Save hash results";
                        dlg.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                        dlg.FileName = "text_hash.txt";
                        if (dlg.ShowDialog(this) != DialogResult.OK)
                        {
                            SetStatus("Save canceled");
                            return;
                        }
                        outPath = dlg.FileName;
                    }
                    content = BuildHashOutputContent("<text input>");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(_currentFilePath))
                    {
                        SetStatus("No file to save");
                        return;
                    }
                    var dir = Path.GetDirectoryName(_currentFilePath) ?? Environment.CurrentDirectory;
                    var baseName = Path.GetFileNameWithoutExtension(_currentFilePath);
                    outPath = Path.Combine(dir, baseName + "_hash.txt");
                    content = BuildHashOutputContent(Path.GetFileName(_currentFilePath));
                }

                File.WriteAllText(outPath, content);
                SetStatus($"Saved: {Path.GetFileName(outPath)}", true, outPath);
            }
            catch (Exception ex)
            {
                SetStatus($"Save failed: {ex.Message}");
            }
        }

        private string BuildHashOutputContent(string source)
        {
            var lines = new List<string>();
            lines.Add($"File: {source}");
            if (chkMD5.Checked) lines.Add($"MD5: {txtHash.Text}");
            if (chkSHA1.Checked) lines.Add($"SHA-1: {txtHashSha1.Text}");
            if (chkSHA256.Checked) lines.Add($"SHA-256: {txtHashSha256.Text}");
            if (chkSHA384.Checked) lines.Add($"SHA-384: {txtHashSha384.Text}");
            if (chkSHA512.Checked) lines.Add($"SHA-512: {txtHashSha512.Text}");
            return string.Join("\r\n", lines) + "\r\n";
        }

        private void txtHash_Click(object sender, EventArgs e)
        {
            try
            {
                var tb = sender as TextBox;
                var text = tb?.Text?.Trim();
                if (!string.IsNullOrEmpty(text) && !text.StartsWith("<"))
                {
                    Clipboard.SetText(text);
                    var which = tb?.Tag as string ?? "Hash";
                    SetStatus($"Copied {which} to clipboard");
                }
                else
                {
                    SetStatus("Nothing to copy");
                }
            }
            catch
            {
                SetStatus("Copy failed");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void lblFileName_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Title = "Select a file";
                    dlg.Filter = "All files (*.*)|*.*";
                    dlg.RestoreDirectory = true;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        await ProcessFileAsync(dlg.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Select file failed: {ex.Message}";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xcodz/OrangeHash/");
        }

        private void MainForm_Load(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void txtStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_lastSavedFilePath) && File.Exists(_lastSavedFilePath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{_lastSavedFilePath}\"");
                }
            }
            catch (Exception ex)
            {
                SetStatus($"Failed to open explorer: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HashSelection_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            _settings.MD5 = chkMD5.Checked;
            _settings.SHA1 = chkSHA1.Checked;
            _settings.SHA256 = chkSHA256.Checked;
            _settings.SHA384 = chkSHA384.Checked;
            _settings.SHA512 = chkSHA512.Checked;
            try { _settings.Save(); } catch { }
        }

        private void linkLabelHashText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter text to hash", "Text to Hash", "");
                if (!string.IsNullOrEmpty(input))
                {
                    _ = ProcessTextAsync(input);
                }
            }
            catch (Exception ex)
            {
                SetStatus($"Text input failed: {ex.Message}");
            }
        }
    }
}
