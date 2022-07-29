/*
 * @lc app=leetcode.cn id=28 lang=csharp
 *
 * [28] 实现 strStr()
 */

// @lc code=start
public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int haystackLength = haystack.Length;
        int needleLength = needle.Length;
        int res = -1;
        for (int i = 0; i < haystackLength - needleLength + 1; i++)
        {
            if (haystack[i] == needle[0] && haystack.Substring(i, needleLength) == needle)
            {
                return i;
            }
        }
        return res;
    }
}
// @lc code=end