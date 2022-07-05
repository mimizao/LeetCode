/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
public class Solution
{
    public string LongestPalindrome(string s)
    {
        int len = s.Length;
        if (len < 2)
        {
            return s;
        }
        bool[,] dp = new bool[len, len];
        for (int i = 0; i < len; i++)
        {
            dp[i,i] = true;
        }
        int maxLen = 1;
        int begin = 0;
        for (int tempLen = 2; tempLen <= len; tempLen++)
        {
            for (int left = 0; left < len; left++)
            {
                int right = left + tempLen - 1;
                if (right >= len)
                {
                    break;
                }
                if (s[left] != s[right])
                {
                    dp[left,right] = false;
                }
                else
                {
                    if (right - left < 3)
                    {
                        dp[left,right] = true;
                    }
                    else
                    {
                        dp[left,right] = dp[left + 1,right - 1];
                    }
                }
                if (dp[left,right] && tempLen > maxLen)
                {
                    begin = left;
                    maxLen = tempLen;
                }
            }
        }
        return s.Substring(begin, maxLen);
    }
}
// @lc code=end

