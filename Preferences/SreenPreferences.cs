using System.Collections.Generic;
using System.Windows.Forms;

namespace pl.polidea.lab.Web_Page_Screensaver
{
    public class SreenPreferences
    {
        public Screen Screen { get; set; }
        public List<string> Urls { get; set; }
        public bool RandomizeUrls { get; set; }
    }
}