using System.Collections.Specialized;
/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        int len = nums.Length;
        IList<IList<int>> res = new List<IList<int>>();
        if (len <= 2)
        {
            return (IList<IList<int>>)res;
        }
        Array.Sort(nums);
        for (int first = 0; first < len - 2; first++)
        {
            if (first != 0 && nums[first] == nums[first - 1])
            {
                continue;
            }
            int third = len - 1;
            int target = 0 - nums[first];
            for (int second = first + 1; second < len - 1; second++)
            {
                if (second != first + 1 && nums[second] == nums[second - 1])
                {
                    continue;
                }
                while (second < third && nums[second] + nums[third] > target)
                {
                    third--;
                }
                if (second == third)
                {
                    break;
                }
                if (nums[second] + nums[third] == target)
                {
                    res.Add(new List<int>() { nums[first], nums[second], nums[third] });
                }
            }
        }
        return res;
    }
}
// @lc code=end

