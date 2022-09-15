using System;
using System.Collections.Generic;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;

            if (index < phrases.Count
                && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return phrases[index];
            }
            else
            {
                return null;
            }
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var phrasesCount = phrases.Count;
            var leftBorder = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrasesCount) + 1;

            if (leftBorder == phrasesCount)
            {
                return new string[0];
            }

            var actualCount = Math.Min(count, phrasesCount - leftBorder);

            var result = new List<string>();
            var nextPhraseIndex = 0;

            for (var i = 0; i < actualCount; i++)
            {
                nextPhraseIndex = leftBorder + i;

                if (!phrases[nextPhraseIndex].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    break;

                result.Add(phrases[nextPhraseIndex]);
            }

            return result.ToArray();
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
            var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);
            var result = right - left - 1;

            return (result <= 0) ? 0 : result;
        }
    }
}