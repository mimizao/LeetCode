/*
 * @lc app=leetcode.cn id=39 lang=golang
 *
 * [39] 组合总和
 */
package main

// @lc code=start
func combinationSum(candidates []int, target int) [][]int {
	n := len(candidates)
	res := [][]int{}
	if n == 0 {
		return res
	}
	path := []int{}
	res = dfs(candidates, 0, n, target, path, res)
	return res
}

func dfs(candidates []int, begin, n, target int, path []int, res [][]int) [][]int {
	if target < 0 {
		return res
	}
	if target == 0 {
		res = append(res, append([]int(nil), path...))
	}
	for i := begin; i < n; i++ {
		path = append(path, candidates[i])
		res = dfs(candidates, i, n, target-candidates[i], path, res)
		path = path[:len(path)-1]
	}
	return res
}

// @lc code=end
