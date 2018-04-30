using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EveChatNotifier.IdleDetector
{
    public static class LastInput
    {
        #region pinvoke.net
        // thanks to:
        // - http://www.pinvoke.net/default.aspx/user32.getlastinputinfo
        // - http://www.pinvoke.net/default.aspx/Structures/LASTINPUTINFO.html

        [DllImport("user32.dll")]
        private static extern Boolean GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        private static uint GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }
        #endregion

        /// <summary>
        /// returns the last intputtime / idletime of the system
        /// </summary>
        /// <returns>idletime</returns>
        public static TimeSpan GetAway()
        {            
            return new TimeSpan(0, 0, (int)GetLastInputTime());
        }
    }
}
