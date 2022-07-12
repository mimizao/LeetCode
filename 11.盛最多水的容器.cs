using System;
/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
public class Solution
{
    public int MaxArea(int[] height)
    {
        int res = 0;
        int left = 0;
        int right = height.Length - 1;
        while (left < right)
        {
            int temp = (right - left) * Math.Min(height[left], height[right]);
            res = temp > res ? temp : res;
            if (height[left] <= height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return res;
    }
}
// @lc code=end

