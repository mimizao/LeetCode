/*
 * @lc app=leetcode.cn id=20 lang=golang
 *
 * [20] 有效的括号
 */
package main

// @lc code=start
func isValid(s string) bool {
	n := len(s)
	if n%2 != 0 {
		return false
	}
	var num1, num2, num3 = 0, 0, 0
	for i := 0; i < n; i++ {
		switch s[i] {
		case '(':
			num1++
		case ')':
			num1--
		case '[':
			num2++
		case ']':
			num2--
		case '{':
			num3++
		case '}':
			num3--
		default:
		}
		if num1 < 0 || num2 < 0 || num3 < 0 {
			return false
		}
	}
	return num1 == 0 && num2 == 0 && num3 == 0
}

// @lc code=end
