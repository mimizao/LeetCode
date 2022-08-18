/*
 * @lc app=leetcode.cn id=47 lang=golang
 *
 * [47] 全排列 II
 */
package main

import "sort"

// @lc code=start
func permuteUnique(nums []int) [][]int {
	sort.Ints(nums)
	var res [][]int
	n := len(nums)
	used := make([]bool, n)
	var path []int
	var depth int
	var permuteUniqueDfs func()
	permuteUniqueDfs = func() {
		if depth == n {
			res = append(res, append([]int{}, path...))
			return
		}
		for i := 0; i < len(nums); i++ {
			if used[i] {
				continue
			}
			if i > 0 && nums[i] == nums[i-1] && !used[i-1] {
				continue
			}
			path = append(path, nums[i])
			used[i] = true
			depth++
			permuteUniqueDfs()
			depth--
			used[i] = false
			path = path[:len(path)-1]
		}
	}
	permuteUniqueDfs()
	return res
}

// @lc code=end
