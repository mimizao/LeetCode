#
# @lc app=leetcode.cn id=58 lang=python3
#
# [58] 最后一个单词的长度
#

# @lc code=start
class Solution:
    def lengthOfLastWord(self, s: str) -> int:
        index = len(s)-1
        while s[index] == ' ':
            index -= 1
        res = 0
        while index >= 0 and s[index] != ' ':
            index -= 1
            res += 1
        return res
# @lc code=end

