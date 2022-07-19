/*
 * @lc app=leetcode.cn id=18 lang=golang
 *
 * [18] 四数之和
 */
package main

import "sort"

// @lc code=start
func fourSum(nums []int, target int) [][]int {
	myLen := len(nums)
	if myLen < 4 {
		return [][]int{}
	}
	res := [][]int{}
	sort.Ints(nums)
	for i := 0; i < myLen-3 && nums[i]+nums[i+1]+nums[i+2]+nums[i+3] <= target; i++ {
		if i > 0 && nums[i] == nums[i-1] || nums[i]+nums[myLen-1]+nums[myLen-2]+nums[myLen-3] < target {
			continue
		}
		for j := i + 1; j < myLen-2 && nums[i]+nums[j]+nums[j+1]+nums[j+2] <= target; j++ {
			if j > i+1 && nums[j] == nums[j-1] || nums[i]+nums[j]+nums[myLen-2]+nums[myLen-1] < target {
				continue
			}
			for left, right := j+1, myLen-1; left < right; {
				if sum := nums[i] + nums[j] + nums[left] + nums[right]; sum == target {
					res = append(res, []int{nums[i], nums[j], nums[left], nums[right]})
					for left++; left < right && nums[left] == nums[left-1]; left++ {
					}
					for right--; left < right && nums[right] == nums[right+1]; right-- {
					}
				} else if sum < target {
					left++
				} else {
					right--
				}
			}
		}
	}
	return res
}

// @lc code=end
