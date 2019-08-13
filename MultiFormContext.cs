using System.Windows.Forms;

namespace pl.polidea.lab.Web_Page_Screensaver
{
    using System.Collections.Generic;

    public class MultiFormContext : ApplicationContext
    {
        public MultiFormContext(List<Form> forms)
        {
            foreach (var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    ExitThread();
                };

                form.Show();
            }
        }
    }
}
