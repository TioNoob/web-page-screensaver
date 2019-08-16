using System;
using WebpageScreensaver.App.View;

namespace WebpageScreensaver.App
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ScreensaverForm screensaverForm = new ScreensaverForm();
            screensaverForm.Run();
        }
    }
}