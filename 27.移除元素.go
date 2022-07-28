/*
 * @lc app=leetcode.cn id=27 lang=golang
 *
 * [27] 移除元素
 */
package main

import (
	"sort"
)

// @lc code=start
func removeElement(nums []int, val int) int {
	len := len(nums)
	if len == 0 {
		return len
	}
	sort.Ints(nums)
	count := 0
	for i := 0; i < len; i++ {
		if nums[i] == val {
			count++
			if nums[i] == nums[len-1] {
				return i
			}
			if i < len-count {
				nums[i] = nums[len-count]
			} else {
				return len - count
			}
		} else if nums[i] > val {
			break
		}
	}
	return len - count
}

// @lc code=end
