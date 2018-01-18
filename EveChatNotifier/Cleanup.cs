using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveChatNotifier
{
    public class Cleanup
    {
        private static Cleanup _Instance = null;

        private Cleanup() { }

        public static Cleanup GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new Cleanup();
                _Instance.FilesToDelete = new List<string>();
            }
            return _Instance;
        }

        /// <summary>
        /// Files which should be delete before the program closes
        /// </summary>
        public List<string> FilesToDelete { get; set; }
    }
}
