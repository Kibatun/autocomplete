using System;
using System.Collections.Generic;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (right - left == 1) return left;
            var mid = (left + right) / 2;
            if (string.Compare(prefix, phrases[mid], StringComparison.OrdinalIgnoreCase) < 0 || phrases[mid].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return GetLeftBorderIndex(phrases, prefix, left, mid);
            return GetLeftBorderIndex(phrases, prefix, mid, right);
        }
    }
}