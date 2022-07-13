using System.Collections.Generic;
using System.IO;
/*
 * @lc app=leetcode.cn id=13 lang=csharp
 *
 * [13] 罗马数字转整数
 */

// @lc code=start
public class Solution
{
    public int RomanToInt(string s)
    {
        Dictionary<char, int> romanByteNum = new Dictionary<char, int>();
        romanByteNum['M'] = 1000;
        romanByteNum['D'] = 500;
        romanByteNum['C'] = 100;
        romanByteNum['L'] = 50;
        romanByteNum['X'] = 10;
        romanByteNum['V'] = 5;
        romanByteNum['I'] = 1;
        int res = romanByteNum[s[0]];
        for (int i = 1; i < s.Length; i++)
        {
            if (romanByteNum[s[i]] > romanByteNum[s[i - 1]])
            {
                res += romanByteNum[s[i]] - 2 * romanByteNum[s[i - 1]];
            }
            else
            {
                res += romanByteNum[s[i]];
            }
        }
        return res;
    }
}
// @lc code=end

