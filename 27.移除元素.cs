using System;
/*
 * @lc app=leetcode.cn id=27 lang=csharp
 *
 * [27] 移除元素
 */

// @lc code=start
public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int len = nums.Length;
        if (len == 0) return len;
        Array.Sort(nums);
        int count = 0;
        for (int i = 0; i < len; i++)
        {
            if (nums[i] == val)
            {
                count++;
                if (nums[i] == nums[len - count])
                {
                    return i;
                }
                if (i < len - count)
                {
                    nums[i] = nums[len - count];
                }
                else
                {
                    return len - count;
                }
            }
            else if (nums[i] > val)
            {
                return len - count;
            }
        }
        return len - count;
    }
}
// @lc code=end

