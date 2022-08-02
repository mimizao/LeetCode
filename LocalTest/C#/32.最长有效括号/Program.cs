// See https://aka.ms/new-console-template for more information
string s = ")()())";
int res = Solution.LongestValidParentheses(s);
Console.WriteLine(s);

public class Solution
{
    public static int LongestValidParentheses(string s)
    {
        int res = 0;
        int[] dp = new int[s.Length];
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == ')')
            {
                if (s[i - 1] == '(')
                {
                    if (i >= 2)
                    {
                        dp[i] = dp[i - 2] + 2;
                    }
                    else
                    {
                        dp[i] = 2;
                    }
                }
                else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                {
                    if (i - dp[i - 1] >= 2)
                    {
                        dp[i] = dp[i - 1] + dp[i - dp[i - 1] - 2] + 2;
                    }
                    else
                    {
                        dp[i] = dp[i - 1] + 2;
                    }
                }
            }
            res = dp[i] > res ? dp[i] : res;
        }
        return res;
    }
}