/*
 * @lc app=leetcode.cn id=14 lang=golang
 *
 * [14] 最长公共前缀
 */
package main

// @lc code=start
func longestCommonPrefix(strs []string) string {
	var strLen = len(strs)
	if strLen <= 1 {
		return strs[0]
	}
	res := strs[0]
	var resLen = len(strs[0])
	for i := 1; i < strLen; i++ {
		res, resLen = getTwoStrsCommonPrefix(res, strs[i], resLen)
		if resLen == 0 {
			return ""
		}
	}
	return res
}

func getTwoStrsCommonPrefix(str1, str2 string, resLen int) (string, int) {
	var newResStrLen = 0
	for i := 0; i < resLen; i++ {
		if i >= len(str1) || i >= len(str2) {
			break
		}
		if str1[i] == str2[i] {
			i++
			newResStrLen++
		}
	}
	return str1[:newResStrLen+1], newResStrLen
}

// @lc code=end
