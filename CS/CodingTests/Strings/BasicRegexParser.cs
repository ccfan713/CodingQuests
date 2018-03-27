using System;
using System.Collections.Generic;

namespace CodingTests.Strings
{
    public class BasicRegexParser
    {
        public static void Test()
        {
            var isMatch = IsMatch("", "a*");
            isMatch = IsMatch("acd", "ab*c.");
            isMatch = IsMatch("abaa", "a.*a*");
        }
        public static bool IsMatch(string text, string pattern)
        {
            List<Sequence> sequence = ExtractSequence(pattern);
            int seqIndex = 0;
            int textIndex = 0;
            bool isMatch = true;

            if (text.Length == 0 && sequence.Count == 1)
            {
                return sequence[0].Type == PatternType.ZeroOrMore;
            }

            while (seqIndex < sequence.Count && textIndex < text.Length && isMatch)
            {
                switch (sequence[seqIndex].Type)
                {
                    case PatternType.Single:
                        isMatch = text[textIndex] == sequence[seqIndex].Character;
                        textIndex++;
                        seqIndex++;
                        break;
                    case PatternType.ZeroOrMore:
                        if (text[textIndex] != sequence[seqIndex].Character)
                        {
                            seqIndex++;
                        }
                        else
                        {
                            textIndex++;
                        }
                        break;
                    case PatternType.Wildcard:
                        seqIndex++;
                        textIndex++;
                        break;
                    case PatternType.ZeroOrMoreWildCard:
                        if (seqIndex < sequence.Count - 1 && text[textIndex] == sequence[seqIndex + 1].Character)
                        {
                            seqIndex++;
                        }
                        else
                        {
                            textIndex++;
                        }
                        break;
                }
            }

            return isMatch && (seqIndex == sequence.Count || (seqIndex == sequence.Count - 1 && (sequence[seqIndex].Type == PatternType.ZeroOrMore || sequence[seqIndex].Type == PatternType.ZeroOrMoreWildCard))) && textIndex == text.Length;
        }

        private static List<Sequence> ExtractSequence(string pattern)
        {
            List<Sequence> sequence = new List<Sequence>();
            int index = 0;
            while (index < pattern.Length)
            {
                Sequence current;
                if (pattern[index].Equals('.'))
                {
                    current = new Sequence { Type = PatternType.Wildcard };
                    index++;
                    if (index < pattern.Length && pattern[index] == '*')
                    {
                        current.Type = PatternType.ZeroOrMoreWildCard;
                        index++;
                    }
                }
                else
                {
                    current = new Sequence { Type = PatternType.Single, Character = pattern[index] };
                    index++;
                    if (index < pattern.Length && pattern[index] == '*')
                    {
                        current.Type = PatternType.ZeroOrMore;
                        index++;
                    }
                }
                sequence.Add(current);
            }
            return sequence;
        }

        public class Sequence
        {
            public PatternType Type { get; set; }
            public char Character { get; set; }
        }

        public enum PatternType
        {
            Single,
            ZeroOrMore,
            Wildcard,
            ZeroOrMoreWildCard
        }
    }
}
