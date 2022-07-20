/*
 * @lc app=leetcode.cn id=20 lang=golang
 *
 * [20] 有效的括号
 */
package main

// @lc code=start
func isValid(s string) bool {
	n := len(s)
	if n%2 != 0 {
		return false
	}
	var numsStack []int = make([]int, n)
	var index int = 0
	for i := 0; i < n; i++ {
		switch s[i] {
		case '(':
			numsStack[index] = 1
			index++
		case ')':
			if index == 0 || numsStack[index-1] != 1 {
				return false
			}
			numsStack[index-1] = 0
			index--
		case '[':
			numsStack[index] = 2
			index++
		case ']':
			if index == 0 || numsStack[index-1] != 2 {
				return false
			}
			numsStack[index-1] = 0
			index--
		case '{':
			numsStack[index] = 3
			index++
		case '}':
			if index == 0 || numsStack[index-1] != 3 {
				return false
			}
			numsStack[index-1] = 0
			index--
		default:
		}
	}
	return numsStack[0] == 0
}

func isValidOfficalIdea(s string) bool {
	n := len(s)
	if n%2 != 0 {
		return false
	}
	myMap := map[byte]byte{
		'(': ')',
		'{': '}',
		'[': ']',
	}
	stack := []byte{}
	for i := 0; i < n; i++ {
		if myMap[s[i]] > 0 {
			if len(stack) == 0 || stack[len(stack)-1] != myMap[s[i]] {
				return false
			}
			stack = stack[:len(stack)-1]
		} else {
			stack = append(stack, s[i])
		}
	}
	return len(stack) == 0
}

// @lc code=end
