/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

// @lc code=start
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        int len = strs.Length;
        if (len <= 1)
        {
            return strs[0];
        }
        string res = strs[0];
        int resLen = res.Length;
        for (int i = 1; i < len; i++)
        {
            res = GetTwoStrsCommonPrefix(res, strs[i], resLen);
            if (res.Length == 0)
            {
                return "";
            }
        }
        return res;
    }

    public string GetTwoStrsCommonPrefix(string str1, string str2, int resLen)
    {
        int newResLen = 0;
        for (int i = 0; i < resLen; i++)
        {
            if (i >= str1.Length || i >= str2.Length)
            {
                break;
            }
            if (str1[i] == str2[i])
            {
                newResLen++;
            }
            else
            {
                break;
            }
        }
        return str1.Substring(0, newResLen);
    }

}
// @lc code=end

