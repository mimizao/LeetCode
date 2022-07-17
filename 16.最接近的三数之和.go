/*
 * @lc app=leetcode.cn id=16 lang=golang
 *
 * [16] 最接近的三数之和
 */
package main

import (
	"math"
	"sort"
)

// @lc code=start
func threeSumClosest(nums []int, target int) int {
	sort.Ints(nums)
	res := nums[0] + nums[1] + nums[2]
	difference := int(math.Abs((float64)(res - target)))
	for first := 0; first < len(nums)-2; first++ {
		second := first + 1
		third := len(nums) - 1
		for second < third {
			newDifference := int(math.Abs((float64)(nums[first] + nums[second] + nums[third] - target)))
			if newDifference == 0 {
				return target
			}
			if newDifference < difference {
				difference = newDifference
				res = nums[first] + nums[second] + nums[third]
			}
			if target > nums[first]+nums[second]+nums[third] {
				second++
				for second < third && nums[second] == nums[second+1] {
					second++
				}
			} else {
				third--
				for second < third && nums[third] == nums[third-1] {
					third--
				}
			}
		}
	}
	return res
}

// @lc code=end
