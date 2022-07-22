/*
 * @lc app=leetcode.cn id=22 lang=golang
 *
 * [22] 括号生成
 */
package main

// wrong idea
// func generateParenthesis(n int) []string {
// 	res := []string{}
// 	res = getNewGenerateParenthesis(n, res)
// 	res = removeDuplicate(res)
// 	return res
// }

// func getNewGenerateParenthesis(n int, res []string) []string {
// 	if n == 1 {
// 		return []string{"()"}
// 	}
// 	if n == 2 {
// 		return []string{"()()", "(())"}
// 	}
// 	res = getNewGenerateParenthesis(n-1, res)
// 	res1 := make([]string, len(res))
// 	res2 := make([]string, len(res))
// 	res3 := make([]string, len(res))
// 	for i := 0; i < len(res); i++ {
// 		res1[i] = "()" + res[i]
// 		res2[i] = "(" + res[i] + ")"
// 		res3[i] = res[i] + "()"
// 	}
// 	res = append([]string{}, res1...)
// 	res = append(res, res2...)
// 	res = append(res, res3...)
// 	return res
// }

// func removeDuplicate(res []string) []string {
// 	newRes := make([]string, 0)
// 	tmpMap := make(map[string]interface{})
// 	for _, val := range res {
// 		if _, ok := tmpMap[val]; !ok {
// 			newRes = append(newRes, val)
// 			tmpMap[val] = nil
// 		}
// 	}
// 	return newRes
// }

// @lc code=start
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

// @lc code=end
