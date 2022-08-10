package main

import (
	"fmt"
	"sort"
)

func main() {
	candidates := []int{3, 1, 3, 5, 1, 1}
	target := 8
	res := combinationSum2(candidates, target)
	fmt.Println(res)
}

func combinationSum2(candidates []int, target int) [][]int {
	n := len(candidates)
	res := [][]int{}
	if n == 0 {
		return res
	}
	sort.Ints(candidates)
	path := []int{}
	res = dfs2(candidates, 0, n, target, path, res)
	return res
}

func dfs2(candidates []int, begin, n, target int, path []int, res [][]int) [][]int {
	if target == 0 {
		res = append(res, append([]int(nil), path...))
		return res
	}
	for i := begin; i < n; i++ {
		if target-candidates[i] < 0 {
			break
		}
		if i > begin && candidates[i] == candidates[i-1] {
			continue
		}
		path = append(path, candidates[i])
		res = dfs2(candidates, i+1, n, target-candidates[i], path, res)
		path = path[:len(path)-1]
	}
	return res
}
