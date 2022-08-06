/*
 * @lc app=leetcode.cn id=38 lang=golang
 *
 * [38] 外观数列
 */
package main

import (
	"strconv"
	"strings"
)

// @lc code=start
func countAndSay(n int) string {
	if n == 1 {
		return "1"
		// } else if n == 2 {
		// 	return "11"
		// } else if n == 3 {
		// 	return "21"
		// } else if n == 4 {
		// 	return "1211"
	} else {
		return getNewRes(countAndSay(n - 1))
	}
}

func getNewRes(str string) string {
	res := ""
	count := 1
	for i := 1; i < len(str); i++ {
		if str[i] != str[i-1] {
			res += strconv.Itoa(count)
			res += string(str[i-1])
			count = 1
		} else {
			count++
		}
	}
	res += strconv.Itoa(count)
	res += string(str[len(str)-1])
	return res
}

func countAndSay1(n int) string {
	res := "1"
	for i := 2; i <= n; i++ {
		cur := &strings.Builder{}
		for j, start := 0, 0; j < len(res); start = j {
			for j < len(res) && res[j] == res[start] {
				j++
			}
			cur.WriteString(strconv.Itoa(j - start))
			cur.WriteByte(res[start])
		}
		res = cur.String()
	}
	return res
}

// @lc code=end
