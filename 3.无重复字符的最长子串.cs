using System.IO;
using System.Net.Http.Headers;
/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length <= 1)
        {
            return s.Length;
        }
        int left = 0;
        int right = 1;
        int res = 1;
        Dictionary<char, int> dir = new Dictionary<char, int>();
        dir[s[left]] = left;
        for (; right < s.Length; right++)
        {
            if (dir.ContainsKey(s[right]) && dir[s[right]] >= left)
            {
                left = dir[s[right]] + 1;
                dir[s[right]] = right;
            }
            else
            {
                dir[s[right]] = right;
                res = (right - left + 1) > res ? (right - left + 1) : res;
            }
        }
        return res;
    }
}
// @lc code=end

