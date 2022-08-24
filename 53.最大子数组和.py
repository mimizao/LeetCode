#
# @lc app=leetcode.cn id=53 lang=python3
#
# [53] 最大子数组和
#
from typing import List

# @lc code=start
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        res = nums[0]
        pre = 0
        for v in nums:
            pre = max(pre + v, v)
            res = max(res, pre)
        return res
# @lc code=end