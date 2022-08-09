/*
 * @lc app=leetcode.cn id=39 lang=golang
 *
 * [39] 组合总和
 */
package main

// @lc code=start
func combinationSum(candidates []int, target int) [][]int {
	res := [][]int{}
	candidatesLen := len(candidates)
	if candidatesLen == 0 {
		return res
	}
	path := []int{}
	dfs(candidates, 0, candidatesLen, target, path, res)
	return res
}

func dfs(candidates []int, begin int, candidatesLen int, target int, path []int, res [][]int) {
	if target < 0 {
		return
	}
	if target == 0 {
		res = append(res, path)
		return
	}
	for i := 0; i < candidatesLen; i++ {
		path = append(path, candidates[i])
		dfs(candidates, i, candidatesLen, target-candidates[i], path, res)
		path = path[:len(path)-1]
	}
}

// @lc code=end
