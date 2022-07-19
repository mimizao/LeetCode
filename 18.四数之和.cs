using System.Collections.Generic;
using System.Security.Cryptography;
/*
 * @lc app=leetcode.cn id=18 lang=csharp
 *
 * [18] 四数之和
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        int len = nums.Length;
        if (len < 4)
        {
            return new List<IList<int>>();
        }
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < len - 3 && (Int64)nums[i] + (Int64)nums[i + 1] + (Int64)nums[i + 2] + (Int64)nums[i + 3] <= (Int64)target; i++)
        {
            Int64 sumI = (Int64)(nums[i]) + (Int64)nums[len - 1] + (Int64)nums[len - 2] + (Int64)nums[len - 3];
            if ((i > 0 && nums[i] == nums[i - 1]) || (sumI < target))
            {
                continue;
            }
            for (int j = i + 1; j < len - 2 && (Int64)nums[i] + (Int64)nums[j] + (Int64)nums[j + 1] + (Int64)nums[j + 2] <= (Int64)target; j++)
            {
                Int64 sumJ = (Int64)nums[i] + (Int64)nums[j] + (Int64)nums[len - 1] + (Int64)nums[len - 2];
                if ((j > i + 1 && nums[j] == nums[j - 1]) || sumJ < target)
                {
                    continue;
                }
                for (int left = j + 1, right = len - 1; left < right;)
                {
                    int sum = nums[i] + nums[j] + nums[left] + nums[right];
                    if (sum == target)
                    {
                        res.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                        do
                        {
                            left++;
                        } while (left < right && nums[left] == nums[left - 1]);
                        do
                        {
                            right--;
                        } while (left < right && nums[right] == nums[right + 1]);
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
        }
        return res;
    }
}
// @lc code=end

