/*
 * @lc app=leetcode.cn id=41 lang=cpp
 *
 * [41] 缺失的第一个正数
 */
#include <vector>
using namespace std;
// @lc code=start
class Solution
{
public:
    int firstMissingPositive(vector<int> &nums)
    {
        int len = nums.size();
        for (int i = 0; i < len; i++)
        {
            if (nums[i] <= 0)
            {
                nums[i] = len+1;
            }
        }
        for (int i = 0; i < len; i++)
        {
            int num = abs(nums[i]);
            if (num <= len)
            {
                nums[num - 1] = -abs(nums[num - 1]);
            }
        }
        for (int i = 0; i < len; i++)
        {
            if (nums[i] > 0)
            {
                return i + 1;
            }
        }
        return len + 1;
    }
};
// @lc code=end
