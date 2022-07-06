/*
 * @lc app=leetcode.cn id=6 lang=golang
 *
 * [6] Z 字形变换
 */
package main

// @lc code=start
func convert(s string, numRows int) string {
	len := len(s)
	if numRows == 1 || len <= numRows {
		return s
	}
	res := make([]byte, 0, len)
	t := 2*numRows - 2
	for i := 0; i < numRows; i++ {
		for j := 0; j+i < len; j += t {
			res = append(res, s[i+j])
			if i > 0 && i < numRows-1 && j+t-i < len {
				res = append(res, s[j+t-i])
			}
		}
	}
	return string(res)
}

// @lc code=end
