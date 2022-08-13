
Solution solution = new Solution();
int[] height = new int[] { 4, 2, 0, 3, 2, 5};
int res = solution.Trap(height);
Console.WriteLine(res);

public class Solution
{
    public int Trap(int[] height)
    {
        int res = 0;
        int len = height.Length;
        if (len == 0) return 0;
        int[] leftMax = new int[len];
        leftMax[0] = height[0];
        for (int i = 1; i < len; i++)
        {
            leftMax[i] = Math.Max(leftMax[i-1],height[i]);
        }
        int[] rightMax = new int[len];
        rightMax[len - 1] = height[len - 1];
        for (int i = len - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i+1],height[i]);
        }
        for (int i = 0; i < len; i++)
        {
            res += Math.Min(leftMax[i],rightMax[i]) - height[i];
        }
        return res;
    }
}