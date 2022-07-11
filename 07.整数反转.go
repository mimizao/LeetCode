/*
 * @lc app=leetcode.cn id=7 lang=golang
 *
 * [7] 整数反转
 */
package main

// @lc code=start
func reverse(x int) int {
	res := 0
	for {
		tmp := x % 10
		if res > 214748364 || (res == 214748364 && tmp > 7) {
			return 0
		}
		if res < -214748364 || (res == -214748364 && tmp < -8) {
			return 0
		}
		res = res*10 + tmp
		x /= 10
		if x == 0 {
			break
		}
	}
	return res
}

// @lc code=end
