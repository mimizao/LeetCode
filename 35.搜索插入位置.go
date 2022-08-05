/*
 * @lc app=leetcode.cn id=35 lang=golang
 *
 * [35] 搜索插入位置
 */
package main

// @lc code=start
func searchInsert(nums []int, target int) int {
	len := len(nums)
	left := 0
	right := len - 1
	for left <= right {
		if target < nums[left] {
			return left
		}
		if target > nums[right] {
			return right + 1
		}
		mid := (left + right) / 2
		if target < nums[mid] {
			right = mid - 1
		} else if target > nums[mid] {
			left = mid + 1
		} else {
			return mid
		}
	}
	return 0
}

// @lc code=end
