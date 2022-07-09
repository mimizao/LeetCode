/*
 * @lc app=leetcode.cn id=8 lang=golang
 *
 * [8] 字符串转换整数 (atoi)
 */
package main

// @lc code=start
func myAtoi(s string) int {
	var res int = 0
	var len int = len(s)
	if len == 0 {
		return 0
	}
	var index int = 0
	for ; index < len; index++ {
		if s[index] == ' ' {
			index++
		}
	}
	s = s[:index]
	len = len - index
	var flag int = 1
	var i int = 0
	if s[0] == '-' {
		flag = -1
		i++
	}
	if s[0] == '+' {
		i++
	}
	for ; i < len; i++ {
		tmp := int(s[i] - '0')
		if tmp < 0 || tmp > 9 {
			return res
		}
		if res > 214748364 || (res == 214748364 && tmp*flag > 7) {
			return 2147483647
		}
		if res < -214748364 || (res == -214748364 && tmp*flag < -8) {
			return -2147483648
		}
		res = res*10 + tmp*flag
	}
	return res
}

// @lc code=end
