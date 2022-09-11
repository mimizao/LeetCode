/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n is 1 or 2) return n;
        var dp = new int[n];
        dp[0] = 1;
        dp[1] = 2;
        for (var i = 2; i < n; i++) dp[i] = dp[i - 1] + dp[i - 2];
        return dp[n - 1];
    }
}
// @lc code=end

