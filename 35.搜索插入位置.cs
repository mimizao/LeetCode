/*
 * @lc app=leetcode.cn id=35 lang=csharp
 *
 * [35] 搜索插入位置
 */

// @lc code=start
public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            if (target < nums[left])
            {
                return left;
            }
            else if (target > nums[right])
            {
                return right + 1;
            }
            else
            {
                int mid = (left + right) / 2;
                if (target < nums[mid])
                {
                    right = mid - 1;
                }
                else if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
        }
        return 0;
    }
}
// @lc code=end

