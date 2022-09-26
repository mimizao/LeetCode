int[] heights = { 2, 1, 5, 6, 2, 3 };
int res = Solution.LargestRectangleArea(heights);
Console.WriteLine(res);

public class Solution
{
    public static int LargestRectangleArea(int[] heights)
    {
        int len = heights.Length;
        switch (len)
        {
            case 0:
                return 0;
            case 1:
                return heights[0];
        }
        int res = 0;
        int[] newHeights = new int[len + 2];
        newHeights[0] = 0;
        Array.Copy(heights, 0, newHeights, 1, len);
        newHeights[^1] = 0;
        len = newHeights.Length;
        Stack<int> stack = new Stack<int>(len);
        stack.Push(0);
        for (int i = 1; i < len; i++)
        {
            while (newHeights[i] < newHeights[stack.Peek()])
            {
                int curHeight = newHeights[stack.Pop()];
                int curWidth = i - stack.Peek() - 1;
                res = Math.Max(res, curHeight * curWidth);
            }
            stack.Push(i);
        }
        return res;
    }
}