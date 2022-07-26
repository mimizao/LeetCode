/*
 * @lc app=leetcode.cn id=26 lang=golang
 *
 * [26] 删除有序数组中的重复项
 */
package main

import "fmt"

func main() {
	nums := []int{1, 1, 1, 1, 1, 2, 3, 4, 5}
	res := removeDuplicates(nums)
	fmt.Println(res)
}

// @lc code=start
func removeDuplicates(nums []int) int {
	len := len(nums)
	if len <= 1 {
		return len
	}
	res := len
	left, right := 0, 1
	for right < len {
		if nums[left] >= nums[right] {
			if nums[left] == nums[len-1] {
				return right
			}
			index := right
			for index < len-1 {
				if nums[index] > nums[left] && nums[index] > nums[right] {
					break
				} else {
					index++
				}
			}
			nums[right] = nums[index]
			res--
		}
		left++
		right++
	}
	return res
}

// @lc code=end
