using System;
using System.Collections.Generic;

namespace Autocomplete
{
    public class RightBorderTask
    {
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            while (right - 1 > left)
            {
                var mid = (right + left) / 2;
                if (string.Compare(prefix, phrases[mid], StringComparison.OrdinalIgnoreCase) >= 0 || phrases[mid].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = mid;
                else right = mid;
            }
            return right;
        }
    }
}