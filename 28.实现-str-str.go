/*
 * @lc app=leetcode.cn id=28 lang=golang
 *
 * [28] 实现 strStr()
 */
package main

import "fmt"

// @lc code=start
func strStr(haystack string, needle string) int {
	haystackLen := len(haystack)
	needleLen := len(needle)
	res := -1
	for i := 0; i < haystackLen-needleLen+1; i++ {
		if haystack[i] == needle[0] && haystack[i:i+needleLen] == needle {
			fmt.Println(haystack[i : i+needleLen])
			return i
		}
	}
	return res
}

// @lc code=end
