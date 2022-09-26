/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
public class Solution
{
    public int LargestRectangleArea(int[] heights)
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
// @lc code=end

