using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveChatNotifier
{
    public static class Extensions
    {
        public static void AddIfNotExist<T>(this List<T> theList, T entry)
        {
            if(!theList.Contains(entry))
            {
                theList.Add(entry);
            }
        }
    }
}
