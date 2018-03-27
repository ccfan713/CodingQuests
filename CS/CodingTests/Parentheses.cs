using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTests
{
    public static class Parentheses
    {
        public static List<string> GenerateParentheses(int n)
        {
            var patterns = new List<string>();
            Generate(n, patterns, string.Empty);
            return patterns;
        }

        private static void Generate(int n, List<string> patterns, string str)
        {
            if(str.Length == 2 * n)
            {
                patterns.Add(str);
            }
            else
            {
                int left = 0;
                int right = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(')
                    {
                        left++;
                    }

                    if (str[i] == ')')
                    {
                        right++;
                    }
                }

                if (left==right)
                {
                    Generate(n, patterns, str + "(");
                }
                else if (right < left)
                {
                    if (left < n)
                    {
                        Generate(n, patterns, str + "(");
                    }

                    Generate(n, patterns, str + ")");
                }
            }
        }
    }
}
