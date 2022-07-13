/*
 * @lc app=leetcode.cn id=12 lang=csharp
 *
 * [12] 整数转罗马数字
 */

// @lc code=start
public class Solution
{
    public string IntToRoman(int num)
    {
        string res = "";
        string[] romanStrs = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] romanNums = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        for (int i = 0; i < romanStrs.Length;)
        {
            if (num >= romanNums[i])
            {
                res += romanStrs[i];
                num -= romanNums[i];
            }
            else
            {
                i++;
            }
        }
        return res;
    }
}
// @lc code=end

