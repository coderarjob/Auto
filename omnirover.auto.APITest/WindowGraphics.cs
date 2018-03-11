using System;
using System.Drawing;
using static omnirover.auto.Win32API;

namespace omnirover.auto.APITest
{
    class WindowGraphics
    {
        public static void DrawRectangle(IntPtr handle)
        {
            IntPtr dc = GetWindowDC(IntPtr.Zero); //get DC for entire screen
            RECT windowRect;
            GetWindowRect(handle, out windowRect);
            Graphics g = Graphics.FromHdc(dc);
            Rectangle windowRectangle = windowRect.ToRectangle();
            //Console.WriteLine(string.Format("{0},{1} {2} {3}", windowRectangle.X,
            //                                  windowRectangle.Y, windowRectangle.Width,
            //                                  windowRectangle.Height));

            g.DrawRectangle(new Pen(Brushes.Red, 1), windowRectangle);

            g.Dispose();
            ReleaseDC(IntPtr.Zero, dc);
        }

        public static void RevomeRectangle(IntPtr handle)
        {
            RECT updaterect;
            InvalidateRect(handle, IntPtr.Zero, true);
            UpdateWindow(handle);
            //GetUpdateRect(handle, out updaterect, false);
            //Console.WriteLine("{0},{1} {2} {3}",updaterect.Left,updaterect.Top,updaterect.Width,updaterect.Height);
            //Console.WriteLine("Update window: " + UpdateWindow(handle).ToString());
        }
    }
}
