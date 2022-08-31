package main

import (
	"fmt"
	"strconv"
)

func main() {
	res := getPermutation1(3, 4)
	fmt.Println(res)
}

func getPermutation(n int, k int) string {
	var path []int
	used := make([]bool, n+1)
	count := 0
	begin := 1
	var dfs func(path []int, used []bool, count, begin int) (int, []int)
	dfs = func(path []int, used []bool, count, begin int) (int, []int) {
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
			count, path = dfs(path, used, count, i+1)
			if count == k {
				return count, path
			}
			used[i] = false
			path = path[:len(path)-1]
		}
		return count, path
	}
	count, path = dfs(path, used, count, begin)
	res := ""
	for i := 0; i < len(path); i++ {
		res += strconv.Itoa(path[i])
	}
	return res
}

func getPermutation1(n int, k int) string {
	res := ""
	used := make([]bool, n+1)
	count := 0
	begin := 1
	var dfs func(res string, used []bool, count, begin int) (int, string)
	dfs = func(res string, used []bool, count, begin int) (int, string) {
		if len(res) == n {
			count++
			return count, res
		}
		for i := 1; i <= n; i++ {
			if used[i] {
				continue
			}
			res += strconv.Itoa(i)
			used[i] = true
			count, res = dfs(res, used, count, i+1)
			if count == k {
				return count, res
			}
			used[i] = false
			res = res[:len(res)-1]
		}
		return count, res
	}
	count, res = dfs(res, used, count, begin)
	return res
}
