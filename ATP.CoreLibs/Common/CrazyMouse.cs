using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATP.CoreLibs.Common
{
    internal static class CrazyMouse
    {
        // Fields
        private static bool active;
        private static Thread crazyMouseThread;
        private static bool enabled;

        // Methods
        static CrazyMouse()
        {
            bool flag;
            active = false;
            if (bool.TryParse(ConfigurationManager.AppSettings["CrazyMouse"], out flag))
            {
                enabled = flag;
            }
            else
            {
                enabled = false;
            }
        }

        private static void MoveCrazyMouse()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            int width = bounds.Width;
            int height = bounds.Height;
            Random random = new Random();
            while (active)
            {
                int x = random.Next(1, width);
                int y = random.Next(1, height);
                int millisecondsTimeout = random.Next(1, 10);
                Cursor.Position = new Point(x, y);
                Thread.Sleep(millisecondsTimeout);
            }
        }

        public static void Start()
        {
            if (enabled && !active)
            {
                active = true;
                crazyMouseThread = new Thread(new ThreadStart(CrazyMouse.MoveCrazyMouse));
                crazyMouseThread.Start();
            }
        }

        public static void Stop()
        {
            if (enabled && active)
            {
                active = false;
                if ((crazyMouseThread != null) && (crazyMouseThread.ThreadState == ThreadState.Running))
                {
                    crazyMouseThread.Join();
                    crazyMouseThread = null;
                }
            }
        }
    }
}
