using System;
using System.Collections;

namespace ScreenObjectXUI.Utils
{
    class StringContainsComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((string)y).Contains((string)x)? 0 : -1;
        }
    }
}

