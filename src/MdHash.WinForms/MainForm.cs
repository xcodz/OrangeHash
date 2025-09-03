using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MdHash.Core.Framework.Abstractions;
using MdHash.Core.Framework.Algorithms;
using MdHash.Core.Framework.Services;

namespace MdHash.WinForms
{
    public partial class MainForm : Form
    {
        private readonly string[] _args;
        private readonly IHashService _hashService = new StreamingHashService();
        private string _currentFilePath = string.Empty;

        public MainForm(string[] args)
        {
            _args = args ?? Array.Empty<string>();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_args.Length > 1)
            {
                var path = _args[1];
                txtStatus.Text = "Working...";
                lblFileName.Text = Path.GetFileName(path);
                _currentFilePath = path;
                BeginHash(path);
                BeginHashSha1(path);
                BeginHashSha256(path);
            }
            else
            {
                txtStatus.Text = "Waiting for file...";
                lblFileName.Text = "No file provided — click to select";
            }
        }

        // Allow dragging the window from anywhere on the form, except on interactive controls.
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int WM_NCLBUTTONDBLCLK = 0xA3;
            const int WM_LBUTTONDBLCLK = 0x0203;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;

            // Suppress maximize on double-click (caption/client) and system maximize commands.
            if (m.Msg == WM_NCLBUTTONDBLCLK || m.Msg == WM_LBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }

            if (m.Msg == WM_SYSCOMMAND)
            {
                int cmd = m.WParam.ToInt32() & 0xFFF0;
                if (cmd == SC_MAXIMIZE)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == HTCLIENT)
                {
                    var pos = PointToClient(Cursor.Position);
                    var ctl = GetChildAtPoint(pos);
                    if (ctl == null || (ctl != txtHash && ctl != txtHashSha1 && ctl != txtHashSha256 && ctl != btnCopy && ctl != btnClose && ctl != lblFileName))
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }

        private async void BeginHash(string path)
        {
            try
            {
                var hash = await Task.Run(() => _hashService
                    .ComputeHashAsync(path, HashAlgorithmKind.MD5)
                    .GetAwaiter()
                    .GetResult());
                txtHash.Text = hash;
                txtStatus.Text = "MD5 — Ready";
            }
            catch
            {
                txtStatus.Text = "MD5 — Error";
            }
        }

        private async void BeginHashSha1(string path)
        {
            try
            {
                var hash = await Task.Run(() => _hashService
                    .ComputeHashAsync(path, HashAlgorithmKind.SHA1)
                    .GetAwaiter()
                    .GetResult());
                txtHashSha1.Text = hash;
            }
            catch
            {
                // leave empty on error
            }
        }

        private async void BeginHashSha256(string path)
        {
            try
            {
                var hash = await Task.Run(() => _hashService
                    .ComputeHashAsync(path, HashAlgorithmKind.SHA256)
                    .GetAwaiter()
                    .GetResult());
                txtHashSha256.Text = hash;
                txtStatus.Text = "Ready";
            }
            catch
            {
                // leave empty on error
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_currentFilePath))
                {
                    txtStatus.Text = "No file to save";
                    return;
                }

                var dir = Path.GetDirectoryName(_currentFilePath) ?? Environment.CurrentDirectory;
                var name = Path.GetFileName(_currentFilePath);
                var baseName = Path.GetFileNameWithoutExtension(_currentFilePath);
                var outPath = Path.Combine(dir, baseName + "_hash.txt");

                var content = $"{name}\r\nMD5: {txtHash.Text}\r\nSHA-1: {txtHashSha1.Text}\r\nSHA-256: {txtHashSha256.Text}\r\n";
                File.WriteAllText(outPath, content);
                txtStatus.Text = $"Saved: {baseName}_hash.txt";
            }
            catch
            {
                txtStatus.Text = "Save failed";
            }
        }

        private void txtHash_Click(object sender, EventArgs e)
        {
            try
            {
                var tb = sender as TextBox;
                var text = tb?.Text?.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    Clipboard.SetText(text);
                    var which = tb?.Tag as string ?? "Hash";
                    txtStatus.Text = $"Copied ({which})";
                }
                else
                {
                    txtStatus.Text = "Nothing to copy";
                }
            }
            catch
            {
                txtStatus.Text = "Copy failed";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblFileName_Click(object sender, EventArgs e)
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
                        _currentFilePath = dlg.FileName;
                        lblFileName.Text = Path.GetFileName(_currentFilePath);
                        txtHash.Text = string.Empty;
                        txtHashSha1.Text = string.Empty;
                        txtHashSha256.Text = string.Empty;
                        txtStatus.Text = "Working...";
                        BeginHash(_currentFilePath);
                        BeginHashSha1(_currentFilePath);
                        BeginHashSha256(_currentFilePath);
                    }
                }
            }
            catch
            {
                txtStatus.Text = "Select file failed";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xcodz/OrangeHash/");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


    }
}
