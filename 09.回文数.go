/*
 * @lc app=leetcode.cn id=9 lang=golang
 *
 * [9] 回文数
 */
package main

import "strconv"

// @lc code=start
func isPalindrome1(x int) bool {
	if x < 0 {
		return false
	}
	var s = strconv.Itoa(x)
	var left, right int = 0, len(s) - 1
	for {
		if s[left] != s[right] {
			return false
		} else {
			left++
			right--
		}
		if left >= right {
			return true
		}
	}
}

// @lc code=end
func isPalindrome(x int) bool {
	if (x < 0) || (x%10 == 0 && x != 0) {
		return false
	}
	var revertedNumber int = 0
	for {
		revertedNumber = revertedNumber*10 + x%10
		x /= 10
		if x < revertedNumber {
			break
		}
	}
	return x == revertedNumber || x == revertedNumber/10
}
