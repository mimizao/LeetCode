/*
 * @lc app=leetcode.cn id=63 lang=csharp
 *
 * [63] 不同路径 II
 */

// @lc code=start
public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[^1][^1] == 1) return 0;
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            if (obstacleGrid[i][0] == 1) break;
            dp[i, 0] = 1;
        }
        for (int i = 0; i < n; i++)
        {
            if (obstacleGrid[0][i] == 1) break;
            dp[0, i] = 1;
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j - 1] == 0 && obstacleGrid[i - 1][j] == 0)
                {
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
                else if (obstacleGrid[i - 1][j] == 1 && obstacleGrid[i][j - 1] == 0)
                {
                    dp[i, j] = dp[i, j - 1];
                }
                else if (obstacleGrid[i][j - 1] == 1 && obstacleGrid[i - 1][j] == 0)
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[m - 1, n - 1];
    }
}
// @lc code=end

