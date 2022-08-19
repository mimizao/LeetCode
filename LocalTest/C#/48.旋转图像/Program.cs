int[][] matrix = new[]
    { new[] { 5, 1, 9, 11 }, new[] { 2, 4, 8, 10 }, new[] { 13, 3, 6, 7 }, new[] { 15, 14, 12, 16 } };
Solution solution = new Solution();
solution.Rotate(matrix);
for (int i = 0; i < matrix.Length; i++)
{
    for (int j = 0; j < matrix[0].Length; j++)
    {
        Console.Write(matrix[i][j] + " ");
    }

    Console.WriteLine();
}

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int len = matrix.Length;
        if (len == 1) return;
        int temp1, temp2, temp3, temp4;
        for (int i = 0; i < (len + 1) / 2; i++)
        {
            for (int j = i; j < len - i - 1; j++)
            {
                temp1 = matrix[i][j];
                temp2 = matrix[j][len - i - 1];
                temp3 = matrix[len - i - 1][len - j - 1];
                temp4 = matrix[len - j - 1][i];

                matrix[i][j] = temp4;
                matrix[j][len - i - 1] = temp1;
                matrix[len - i - 1][len - j - 1] = temp2;
                matrix[len - j - 1][i] = temp3;
            }
        }

        return;
    }
}