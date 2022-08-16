/*
 * @lc app=leetcode.cn id=45 lang=csharp
 *
 * [45] 跳跃游戏 II
 */

// @lc code=start
public class Solution
{
    public int Jump(int[] nums)
    {
        int len = nums.Length;
        int count = 0;
        int begin = 0;
        while (begin <= len - 1)
        {
            if (begin == len - 1)
            {
                break;
            }
            else if (begin + nums[begin] >= len - 1)
            {
                count++;
                break;
            }
            else
            {
                int temp = 0;
                int newBegin = begin;
                for (int i = 1; i <= nums[begin]; i++)
                {
                    if (temp <= nums[begin + i] + i)
                    {
                        temp = nums[begin + i] + i;
                        newBegin = begin + i;
                    }
                }
                count++;
                begin = newBegin;
            }
        }
        return count;
    }
}
// @lc code=end