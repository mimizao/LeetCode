package main

import (
	"fmt"
)

func myAtoi(s string) int {
	var res int = 0
	var len int = len(s)
	if len == 0 {
		return 0
	}
	var count int = 0
	for i := 0; i < len; i++ {
		if s[i] == ' ' {
			count++
		} else {
			break
		}
	}
	s = s[count:len]
	len = len - count
	if len == 0 {
		return 0
	}
	var flag int = 1
	var i int = 0
	if s[0] == '-' {
		flag = -1
		i++
	}
	if s[0] == '+' {
		i++
	}
	for ; i < len; i++ {
		tmp := int(s[i] - '0')
		if tmp < 0 || tmp > 9 {
			return res
		}
		if res > 214748364 || (res == 214748364 && tmp*flag > 7) {
			return 2147483647
		}
		if res < -214748364 || (res == -214748364 && tmp*flag < -8) {
			return -2147483648
		}
		res = res*10 + tmp*flag
	}
	return res
}

func main() {
	var s = "   -42"
	fmt.Println(myAtoi(s))
}
