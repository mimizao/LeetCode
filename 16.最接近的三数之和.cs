using System;
using System.Globalization;
using System.Collections.Specialized;

/*
 * @lc app=leetcode.cn id=16 lang=csharp
 *
 * [16] 最接近的三数之和
 */

// @lc code=start
public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int res = nums[0] + nums[1] + nums[2];
    }
}
// @lc code=end

