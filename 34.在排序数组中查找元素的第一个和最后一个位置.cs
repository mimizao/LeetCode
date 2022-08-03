/*
 * @lc app=leetcode.cn id=34 lang=csharp
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 */

// @lc code=start
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int[] res = new int[2] { -1, -1 };
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                int begin = mid;
                int end = mid;
                while (begin > 0 && nums[begin - 1] == target)
                {
                    begin--;
                }
                while (end < nums.Length - 1 && nums[end + 1] == target)
                {
                    end++;
                }
                return new int[] { begin, end };
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return res;
    }
}
// @lc code=end

