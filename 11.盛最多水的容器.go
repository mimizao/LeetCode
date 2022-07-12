/*
 * @lc app=leetcode.cn id=11 lang=golang
 *
 * [11] 盛最多水的容器
 */
package main

// @lc code=start
func maxArea(height []int) int {
	var res int = 0
	var left int = 0
	var right int = len(height) - 1
	for {
		tmpRes := (right - left) * min(height[left], height[right])
		if tmpRes > res {
			res = tmpRes
		}
		if height[left] <= height[right] {
			left++
		} else {
			right--
		}
		if left >= right {
			break
		}
	}
	return res
}

func min(x, y int) int {
	if x <= y {
		return x
	}
	return y
}

// @lc code=end
