using System;
using System.Windows.Forms;

namespace TranslationJetBrains
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Main());    //MessageBox.Show(new JHandle().TranslateFromGoogleService("\",\"", new GoogleTranslateToken.TKK().GetTKK()));
        }
    }
}