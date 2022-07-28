package main

import "fmt"

func main() {
	res := generateParenthesis(3)
	fmt.Println(res)
}

func generateParenthesis(n int) []string {
	var res []string
	generate(&res, "", 0, 0, n)
	return res
}

func generate(res *[]string, str string, leftCount, rightCount, n int) {
	if leftCount > n || rightCount > n || rightCount > leftCount {
		return
	}
	if leftCount == n && rightCount == n {
		*res = append(*res, str)
	}
	generate(res, str+"(", leftCount+1, rightCount, n)
	generate(res, str+")", leftCount, rightCount+1, n)
}
