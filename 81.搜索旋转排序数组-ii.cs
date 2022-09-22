/*
 * @lc app=leetcode.cn id=81 lang=csharp
 *
 * [81] 搜索旋转排序数组 II
 */

// @lc code=start
public class Solution {
    public bool Search(int[] nums, int target)
    {
        int len = nums.Length;
        if (len == 1) return nums[0] == target;
        int begin = 0;
        int end = len - 1;
        while (begin <= end)
        {
            int mid = (begin + end) / 2;
            if (nums[mid] == target) return true;
            if (nums[begin] == nums[mid] && nums[mid] == nums[end])
            {
                begin++;
                end--;
            }
            else if (nums[begin] <= nums[mid])
            {
                if (nums[begin] <= target && target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    begin = mid + 1;
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[^1])
                {
                    begin = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
        }
        return false;
    }
}
// @lc code=end

