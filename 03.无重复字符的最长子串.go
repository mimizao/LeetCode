/*
 * @lc app=leetcode.cn id=3 lang=golang
 *
 * [3] 无重复字符的最长子串
 */
package main

// @lc code=start
func lengthOfLongestSubstring(s string) int {
	if len(s) <= 1 {
		return len(s)
	}
	var (
		left  = 0
		right = 1
		res   = 1
	)
	byteIndex := make(map[byte]int)
	byteIndex[s[left]] = left
	for ; right < len(s); right++ {
		if tempIndex, ok := byteIndex[s[right]]; ok && tempIndex >= left {
			left = tempIndex + 1
			byteIndex[s[right]] = right

		} else {
			byteIndex[s[right]] = right
			if right-left+1 > res {
				res = right - left + 1
			}
		}

	}
	return res
}

// @lc code=end
