using System.Collections.Generic;
using System.Windows.Forms;

namespace WebpageScreensaver.App.Preferences
{
    public class SreenPreferences
    {
        public Screen Screen { get; set; }
        public List<string> Urls { get; set; }
        public bool RandomizeUrls { get; set; }
    }
}