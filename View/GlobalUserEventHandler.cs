using System.Drawing;
using System.Windows.Forms;

namespace pl.polidea.lab.Web_Page_Screensaver
{
    public class GlobalUserEventHandler : IMessageFilter
    {
        public delegate void UserEvent();

        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_MBUTTONDBLCLK = 0x209;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;

        private Point? lastMousePos;
        public event UserEvent Event;

        public bool PreFilterMessage(ref Message message)
        {
            int messageId = message.Msg;

            if (messageId == WM_MOUSEMOVE && lastMousePos == null)
            {
                lastMousePos = Cursor.Position;
            }

            if ((messageId == WM_MOUSEMOVE && (Cursor.Position != lastMousePos))
                || (messageId > WM_MOUSEMOVE && messageId <= WM_MBUTTONDBLCLK) || messageId == WM_KEYDOWN || messageId == WM_KEYUP)
            {
                Event?.Invoke();
            }

            return false;
        }
    }
}