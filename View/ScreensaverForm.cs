using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Web_Page_Screensaver.Extension;

namespace pl.polidea.lab.Web_Page_Screensaver
{
    public partial class ScreensaverForm : Form
    {
        private int currentSiteIndex = -1;

        private readonly ScreensaverPreferences screensaverPreferences = new ScreensaverPreferences();

        public ScreensaverForm()
        {
            Location = new Point(screensaverPreferences.PrimaryScreen.Bounds.Left, screensaverPreferences.PrimaryScreen.Bounds.Top);
            Size = new Size(screensaverPreferences.PrimaryScreen.Bounds.Width, screensaverPreferences.PrimaryScreen.Bounds.Height);

            SetGlobalEventHandler();

            InitializeComponent();

            Cursor.Hide();
        }

        private void SetGlobalEventHandler()
        {
            GlobalUserEventHandler userEventHandler = new GlobalUserEventHandler();
            userEventHandler.Event += HandleUserActivity;
        }

        private void ScreensaverForm_Load(object sender, EventArgs e)
        {
            if (screensaverPreferences.Urls.Any())
            {
                if (screensaverPreferences.RandomizeUrls)
                {
                    screensaverPreferences.Urls = screensaverPreferences.Urls.Shuffle();
                }

                InitializeTimer();
                ShowNextSite();
            }
            else
            {
                Close();
            }
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer
            {
                Interval = screensaverPreferences.RotateInterval * 1000
            };
            timer.Tick += (s, ee) => ShowNextSite();
            timer.Start();
        }

        private void BrowseTo(string url)
        {
            webBrowser.Visible = true;
            try
            {
                Debug.WriteLine($"Navigating: {url}");

                webBrowser.Navigate(url);
            }
            catch
            {
                Debug.WriteLine($"An error ocurred trying to load the URL: {url}");
            }
        }

        private void ShowNextSite()
        {
            currentSiteIndex++;

            List<string> urls = screensaverPreferences.Urls;

            if (currentSiteIndex >= urls.Count)
            {
                currentSiteIndex = 0;
            }

            BrowseTo(urls[currentSiteIndex]);
        }

        private void HandleUserActivity()
        {
            if (screensaverPreferences.CloseOnActivity)
            {
                Close();
            }
            else
            {
                closeButton.Visible = true;
                Cursor.Show();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
