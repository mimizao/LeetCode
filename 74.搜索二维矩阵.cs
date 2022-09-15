/*
 * @lc app=leetcode.cn id=74 lang=csharp
 *
 * [74] 搜索二维矩阵
 */

// @lc code=start
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix[0][0] > target || matrix[^1][^1] < target)
        {
            return false;
        }

        int m = matrix.Length;
        int n = matrix[0].Length;
        int left = 0;
        int right = m;
        int row = -1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (matrix[mid][0] <= target && target <= matrix[mid][^1])
            {
                row = mid;
                break;
            }

            if (matrix[mid][0] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        if (row is -1)
        {
            return false;
        }

        left = 0;
        right = n;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (matrix[row][mid] == target)
            {
                return true;
            }

            if (matrix[row][mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
}
// @lc code=end

