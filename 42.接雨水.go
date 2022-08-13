/*
 * @lc app=leetcode.cn id=42 lang=golang
 *
 * [42] 接雨水
 */
package main

// @lc code=start
func trap(height []int) int {
	res := 0
	n := len(height)
	if n == 0 {
		return res
	}
	leftMax := make([]int, n)
	leftMax[0] = height[0]
	for i := 1; i < n; i++ {
		leftMax[i] = trapMax(leftMax[i-1], height[i])
	}
	rightMax := make([]int, n)
	rightMax[n-1] = height[n-1]
	for i := n - 2; i >= 0; i-- {
		rightMax[i] = trapMax(rightMax[i+1], height[i])
	}
	for i, h := range height {
		res += trapMin(leftMax[i], rightMax[i]) - h
	}
	return res
}

func trapMax(a, b int) int {
	if a < b {
		return b
	}
	return a
}

func trapMin(a, b int) int {
	if a < b {
		return a
	}
	return b
}

// @lc code=end
