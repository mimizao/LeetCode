#
# @lc app=leetcode.cn id=66 lang=python3
#
# [66] 加一
#
from typing import List

# @lc code=start
class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        if digits[-1] < 9:
            digits[-1] += 1
            return digits
        else:
            digits[-1] = 0
            flag = 1
        end = len(digits) - 2
        while end >= 0:
            if flag == 1:
                if digits[end] < 9:
                    digits[end] += 1
                    return digits
                else:
                    digits[end] = 0
                    flag = 1
            else:
                return digits
            end -= 1
        res = [0] * (len(digits)+1)
        res[0] = 1
        return res
# @lc code=end

