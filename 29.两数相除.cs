/*
 * @lc app=leetcode.cn id=29 lang=csharp
 *
 * [29] 两数相除
 */

// @lc code=start
public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == 0) return 0;
        if (divisor == 1) return dividend;
        if (divisor == -1)
        {
            if (dividend > Int32.MinValue) return -dividend;
            return Int32.MaxValue;
        }
        int flag = 1;
        if ((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0))
        {
            flag = -1;
        }
        long newDividend = Convert.ToInt64(dividend);
        long newDivisor = Convert.ToInt64(divisor);
        newDividend = newDividend > 0 ? newDividend : -newDividend;
        newDivisor = newDivisor > 0 ? newDivisor : -newDivisor;
        long res = Div(newDividend, newDivisor);
        if (flag > 0)
        {
            return res > Int32.MaxValue ? Int32.MinValue : Convert.ToInt32(res);
        }
        return Convert.ToInt32(-res);
    }
    public long Div(long newDividend, long newDivisor)
    {
        if (newDividend < newDivisor) return 0;
        long count = 1;
        long tempNewDivisor = newDivisor;
        while (tempNewDivisor + tempNewDivisor <= newDividend)
        {
            count += count;
            tempNewDivisor += tempNewDivisor;
        }
        return count + Div(newDividend - tempNewDivisor, newDivisor);
    }
}
// @lc code=end