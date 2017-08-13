using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EveChatNotifier.Props

{
    class Program
    {
        [System.ComponentModel.DefaultValue(false)]
        public bool UseRegex { get; set; }

        [System.ComponentModel.DefaultValue(@"\[(?<senddate>(.+))\](?<sender>(.*))\>(?<text>(.*))")]
        public string RegexMatch { get; set; }
    }
}