/*
 * @lc app=leetcode.cn id=17 lang=golang
 *
 * [17] 电话号码的字母组合
 */
package main

// @lc code=start

var myMap = map[byte]string{
	'2': "abc",
	'3': "def",
	'4': "ghi",
	'5': "jkl",
	'6': "mno",
	'7': "pqrs",
	'8': "tuv",
	'9': "wxyz",
}

func letterCombinations(digits string) []string {
	if len(digits) == 0 {
		return []string{}
	}
	var res []string = []string{}
	res = getNewRes(res, digits, 0, "")
	return res
}

func getNewRes(res []string, digits string, index int, suffix string) []string {
	if index == len(digits) {
		res = append(res, suffix)
		return res
	} else {
		digit := digits[index]
		letters := myMap[digit]
		lettersCount := len(letters)
		for i := 0; i < lettersCount; i++ {
			res = getNewRes(res, digits, index+1, suffix+string(letters[i]))
		}
	}
	return res
}

// @lc code=end
