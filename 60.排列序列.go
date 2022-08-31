/*
 * @lc app=leetcode.cn id=60 lang=golang
 *
 * [60] 排列序列
 */
package main

import "strconv"

// @lc code=start
func getPermutation(n int, k int) string {
	var path []int
	used := make([]bool, n+1)
	count := 0
	var dfs func(path []int, used []bool, count int) (int, []int)
	dfs = func(path []int, used []bool, count int) (int, []int) {
		if len(path) == n {
			count++
			return count, path
		}
		for i := 1; i <= n; i++ {
			if used[i] {
				continue
			}
			path = append(path, i)
			used[i] = true
			count, path = dfs(path, used, count)
			if count == k {
				return count, path
			}
			used[i] = false
			path = path[:len(path)-1]
		}
		return count, path
	}
	count, path = dfs(path, used, count)
	res := ""
	for i := 0; i < len(path); i++ {
		res += strconv.Itoa(path[i])
	}
	return res
}

// @lc code=end
