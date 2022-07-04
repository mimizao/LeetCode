/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] res = new int[2]{0,1};
        Dictionary<int, int> dir = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = target - nums[i];
            if (dir.ContainsKey(temp) && dir[temp] != i)
            {
                res = new int[2] { dir[temp], i };
                return res;
            }
            else
            {
                dir[nums[i]] = i;
            }
        }
        return res;
    }
}
// @lc code=end