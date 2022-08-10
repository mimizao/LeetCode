/*
 * @lc app=leetcode.cn id=41 lang=csharp
 *
 * [41] 缺失的第一个正数
 */

// @lc code=start
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            if (nums[i] <= 0) nums[i] = len + 1;
        }
        for (int i = 0; i < len; i++)
        {
            int num = Math.Abs(nums[i]);
            if (num <= len)
            {
                nums[num - 1] = -Math.Abs(nums[num - 1]);
            }
        }
        for (int i = 0; i < len; i++)
        {
            if (nums[i] > 0) return i + 1;
        }
        return len + 1;
    }
}
// @lc code=end

