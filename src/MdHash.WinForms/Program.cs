using System;
using System.Windows.Forms;

namespace MdHash.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var args = Environment.GetCommandLineArgs();
            Application.Run(new MainForm(args));
        }
    }
}

