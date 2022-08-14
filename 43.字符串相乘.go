/*
 * @lc app=leetcode.cn id=43 lang=golang
 *
 * [43] 字符串相乘
 */
package main

import "strconv"

// @lc code=start

func multiply(num1 string, num2 string) string {
	if num1 == "0" || num2 == "0" {
		return "0"
	}
	res := "0"
	len1, len2 := len(num1), len(num2)
	for i := len2 - 1; i >= 0; i-- {
		curr := ""
		add := 0
		for j := len2 - 1; j > i; j-- {
			curr += "0"
		}
		y := int(num2[i] - '0')
		for j := len1 - 1; j >= 0; j-- {
			x := int(num1[j] - '0')
			product := x*y + add
			curr = strconv.Itoa(product%10) + curr
			add = product / 10
		}
		for ; add != 0; add /= 10 {
			curr = strconv.Itoa(add%10) + curr
		}
		res = addStrings(res, curr)
	}
	return res
}

func addStrings(num1 string, num2 string) string {
	index1, index2 := len(num1)-1, len(num2)-1
	add := 0
	res := ""
	for ; index1 >= 0 || index2 >= 0 || add != 0; index1, index2 = index1-1, index2-1 {
		x, y := 0, 0
		if index1 >= 0 {
			x = int(num1[index1] - '0')
		}
		if index2 >= 0 {
			y = int(num2[index2] - '0')
		}
		tempRes := x + y + add
		res = strconv.Itoa(tempRes%10) + res
		add = tempRes / 10
	}
	return res
}

// @lc code=end
