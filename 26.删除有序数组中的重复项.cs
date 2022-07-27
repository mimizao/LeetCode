/*
 * @lc app=leetcode.cn id=26 lang=csharp
 *
 * [26] 删除有序数组中的重复项
 */

// @lc code=start
public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int len = nums.Length;
        if (len <= 1)
        {
            return len;
        }
        int res = len;
        int left = 0;
        int right = 1;
        while (right < len)
        {
            if (nums[left] >= nums[right])
            {
                if (nums[left] == nums[len - 1])
                {
                    System.Console.WriteLine(right);
                    return right;
                }
                int index = right;
                while (index < len - 1)
                {
                    if (nums[index] > nums[left] && nums[index] > nums[right])
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
                nums[right] = nums[index];
                res--;
            }
            left++;
            right++;
        }
        return res;
    }
}
// @lc code=end

