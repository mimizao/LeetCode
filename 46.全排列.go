/*
 * @lc app=leetcode.cn id=46 lang=golang
 *
 * [46] 全排列
 */
package main

// @lc code=start
func permute(nums []int) [][]int {
	var res [][]int
	if len(nums) == 0 {
		return res
	}
	var path []int
	used := make([]bool, len(nums))
	var dfs func()
	dfs = func() {
		if len(path) == len(nums) {
			res = append(res, append([]int{}, path...))
			return
		}
		for i := 0; i < len(nums); i++ {
			if used[i] {
				continue
			}
			path = append(path, nums[i])
			used[i] = true
			dfs()
			used[i] = false
			path = path[0 : len(path)-1]
		}
	}
	dfs()
	return res
}

// @lc code=end
