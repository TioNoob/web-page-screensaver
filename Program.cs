using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace pl.polidea.lab.Web_Page_Screensaver
{
    using System.Drawing;

    static class Program
    {
        private const string KeyName = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        private const int Value = 0x2AF8;

        [STAThread]
        static void Main()
        {
            string exeName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Registry.SetValue(KeyName, exeName, Value, RegistryValueKind.DWord); // Cê vai morrer antes do natal

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Screen primaryScreen = new PreferencesManager().PrimaryScreen;
            ScreensaverForm screensaverForm = new ScreensaverForm
            {
                Location = new Point(primaryScreen.Bounds.Left, primaryScreen.Bounds.Top),
                Size = new Size(primaryScreen.Bounds.Width, primaryScreen.Bounds.Height)
            };

            Application.Run(screensaverForm);
        }
    }
}
