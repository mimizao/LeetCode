/*
 * @lc app=leetcode.cn id=31 lang=golang
 *
 * [31] 下一个排列
 */
package main

// @lc code=start
func nextPermutation(nums []int) {
	len := len(nums)
	left := len - 2
	for left >= 0 && nums[left] >= nums[left+1] {
		left--
	}
	if left >= 0 {
		right := len - 1
		for right >= 0 && nums[left] >= nums[right] {
			right--
		}
		nums[left], nums[right] = nums[right], nums[left]
	}
	newReverse(nums[left+1:])
}

func newReverse(a []int) {
	for index, len := 0, len(a); index < len/2; index++ {
		a[index], a[len-1-index] = a[len-1-index], a[index]
	}
}

// @lc code=end
