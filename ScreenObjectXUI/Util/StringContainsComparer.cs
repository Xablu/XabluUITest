namespace ScreenObjectXUI.Utils
{
    using System.Collections;

    class StringContainsComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((string)y).Contains((string)x)? 0 : -1;
        }
    }
}

