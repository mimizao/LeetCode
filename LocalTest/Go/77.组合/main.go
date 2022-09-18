package main

import "fmt"

func combine(n int, k int) [][]int {
	var res [][]int
	var path []int
	var used = make([]bool, n+1)
	var dsf func()
	dsf = func() {
		if len(path) == k {
			res = append(res, append([]int{}, path...))
			return
		}
		for i := 1; i <= n; i++ {
			if used[i] || (len(path) > 0 && i > path[len(path)-1]) {
				continue
			}
			used[i] = true
			path = append(path, i)
			dsf()
			path = path[:len(path)-1]
			used[i] = false
		}
		return
	}
	dsf()
	return res
}

func main() {
	n, k := 4, 2
	var res = combine(n, k)
	fmt.Println(res)
}
