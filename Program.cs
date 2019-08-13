using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace pl.polidea.lab.Web_Page_Screensaver
{
    static class Program
    {
        private const string KeyName = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        private const int Value = 0x2AF8;

        [STAThread]
        static void Main()
        {
            string exeName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Registry.SetValue(KeyName, exeName, Value, RegistryValueKind.DWord); // You will die before christmas

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ScreensaverForm screensaverForm = new ScreensaverForm();

            Application.Run(screensaverForm);
        }
    }
}
