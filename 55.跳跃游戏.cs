/*
 * @lc app=leetcode.cn id=55 lang=csharp
 *
 * [55] 跳跃游戏
 */

// @lc code=start
public class Solution
{
    public bool CanJump(int[] nums)
    {
        int index = 0;
        while (index + nums[index] < nums.Length - 1)
        {
            if (nums[index] == 0) return false;
            int temp = 0;
            int newIndex = index + 1;
            for (var distance = 1; distance <= nums[index]; distance++)
            {
                if (nums[index + distance] + distance < temp) continue;
                temp = nums[index + distance] + distance;
                newIndex = index + distance;
            }
            index = newIndex;
        }
        return true;
    }
}
// @lc code=end

