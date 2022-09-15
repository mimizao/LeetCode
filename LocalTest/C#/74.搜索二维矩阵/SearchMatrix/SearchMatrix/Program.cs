int[][] matrix = { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } };
const int target = 3;
Solution solution = new Solution();
bool res = solution.SearchMatrix(matrix, target);
Console.WriteLine(res);

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