/*
 * @lc app=leetcode.cn id=29 lang=golang
 *
 * [29] 两数相除
 */
package main

// @lc code=start
func divide(dividend int, divisor int) int {
	if dividend == 0 {
		return 0
	}
	if divisor == 1 {
		return dividend
	}
	if divisor == -1 {
		if dividend > -2147483648 {
			return -dividend
		}
		return 2147483647
	}
	flag := 1
	if (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0) {
		flag = -1
	}
	newDividend := int64(dividend)
	newDivisor := int64(divisor)
	if newDividend < 0 {
		newDividend = -newDividend
	}
	if newDivisor < 0 {
		newDivisor = -newDivisor
	}
	res := div(newDividend, newDivisor)
	if flag > 0 {
		if res > 2147483647 {
			return 2147483647
		}
		return int(res)
	}
	return int(-res)
}

func div(newDividend int64, newDivisor int64) int64 {
	if newDividend < newDivisor {
		return 0
	}
	var count int64 = 1
	var tempNewDivisor int64 = newDivisor
	for tempNewDivisor+tempNewDivisor <= newDividend {
		count += count
		tempNewDivisor += tempNewDivisor
	}
	return count + div(newDividend-tempNewDivisor, newDivisor)
}

// @lc code=end
