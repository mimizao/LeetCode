from typing import List


class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        res = nums[0]
        pre = 0
        for v in nums:
            pre = max(pre + v, v)
            res = max(res, pre)
        return res


if __name__ == '__main__':
    myNums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    solution = Solution()
    myRes = solution.maxSubArray(myNums)
    print(myRes)
