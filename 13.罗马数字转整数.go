/*
 * @lc app=leetcode.cn id=13 lang=golang
 *
 * [13] 罗马数字转整数
 */
package main

// @lc code=start
func romanToInt(s string) int {
	var romanByteNum = make(map[byte]int)
	romanByteNum['M'] = 1000
	romanByteNum['D'] = 500
	romanByteNum['C'] = 100
	romanByteNum['L'] = 50
	romanByteNum['X'] = 10
	romanByteNum['V'] = 5
	romanByteNum['I'] = 1
	var res int = romanByteNum[s[0]]
	for i := 1; i < len(s); i++ {
		if romanByteNum[s[i]] > romanByteNum[s[i-1]] {
			res += romanByteNum[s[i]] - 2*romanByteNum[s[i-1]]
		} else {
			res += romanByteNum[s[i]]
		}
	}
	return res
}

// @lc code=end
