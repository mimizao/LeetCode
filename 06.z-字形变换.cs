using System.Text;
using System.Security.Cryptography;
using System.Globalization;
/*
 * @lc app=leetcode.cn id=6 lang=csharp
 *
 * [6] Z 字形变换
 */

// @lc code=start
public class Solution
{
    public string Convert(string s, int numRows)
    {
        int len = s.Length;
        if (numRows == 1 || len <= numRows)
        {
            return s;
        }
        StringBuilder sb = new StringBuilder();
        int t = 2 * numRows - 2;
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j + i < len; j += t)
            {
                sb.Append(s[j + i]);
                if (i > 0 && i < numRows - 1 && j + t - i < len)
                {
                    sb.Append(s[j + t - i]);
                }
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

