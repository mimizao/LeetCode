/*
 * @lc app=leetcode.cn id=5 lang=golang
 *
 * [5] 最长回文子串
 */

// @lc code=start
package main

func longestPalindrome(s string) string {
	len := len(s)
	if len < 2 {
		return s
	}
	var dp [1000][1000]bool
	for i := range s {
		dp[i][i] = true
	}
	maxLen := 1
	begin := 0
	for tempLen := 2; tempLen <= len; tempLen++ {
		for left := 0; left < len; left++ {
			right := left + tempLen - 1
			if right >= len {
				break
			}
			if s[left] != s[right] {
				dp[left][right] = false
			} else {
				if right-left < 3 {
					dp[left][right] = true
				} else {
					dp[left][right] = dp[left+1][right-1]
				}
			}
			if dp[left][right] && right-left+1 > maxLen {
				maxLen = right - left + 1
				begin = left
			}
		}
	}
	return s[begin : begin+maxLen]
}

// @lc code=end
