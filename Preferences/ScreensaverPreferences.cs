namespace pl.polidea.lab.Web_Page_Screensaver
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public class ScreensaverPreferences
    {
        private const string URL_PREF_PRIMARYSCREEN_DEFAULT = "https://www.google.com/trends/hottrends/visualize?nrow=5&ncol=5 https://screensaver.twingly.com/";

        public ScreensaverPreferences()
        {
            CloseOnActivity = true;
            Urls = LoadUrlsAllScreens();
            RandomizeUrls = false;
            CloseOnActivity = true;
            RotateInterval = 60;
        }

        private Screen _primaryScreen;
        public Screen PrimaryScreen
        {
            get
            {
                if(_primaryScreen == null)
                {
                    _primaryScreen = Screen.AllScreens.First(screen => screen.Primary);
                }

                return _primaryScreen;
            }
        }
        public List<string> Urls { get; set; }
        public bool RandomizeUrls { get; set; }
        public bool CloseOnActivity { get; set; }
        public int RotateInterval { get; set; }

        private List<string> LoadUrlsAllScreens()
        {
            return URL_PREF_PRIMARYSCREEN_DEFAULT
                .Split(',')
                .ToList();
        }
    }
}