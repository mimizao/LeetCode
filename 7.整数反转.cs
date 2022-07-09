using System.Data;
/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
public class Solution
{
    public int Reverse(int x)
    {
        int res = 0;
        while (x != 0)
        {
            int temp = x % 10;
            if (res > 214748364 || (res == 214748364 && temp > 7))
            {
                return 0;
            }
            if (res < -214748364 || (res == -214748364 && temp < -8))
            {
                return 0;
            }
            res = res * 10 + temp;
            x /= 10;
        }
        return res;
    }
}
// @lc code=end

