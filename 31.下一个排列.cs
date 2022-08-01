/*
 * @lc app=leetcode.cn id=31 lang=csharp
 *
 * [31] 下一个排列
 */

// @lc code=start
public class Solution
{
    public void NextPermutation(int[] nums)
    {
        int len = nums.Length;
        int left = len - 2;
        int right = len - 1;
        for (; left >= 0 && nums[left] >= nums[left + 1]; left--) { }
        if (left >= 0)
        {
            for (; right >= 0 && nums[left] >= nums[right]; right--) { }
            nums[left] ^= nums[right];
            nums[right] ^= nums[left];
            nums[left] ^= nums[right];
        }
        ReverseNums(nums, left + 1);
        return;
    }

    public void ReverseNums(int[] nums, int left)
    {
        int right = nums.Length - 1;
        while (left < right)
        {
            nums[left] ^= nums[right];
            nums[right] ^= nums[left];
            nums[left] ^= nums[right];
            left++;
            right--;
        }
        return;
    }
}
// @lc code=end

