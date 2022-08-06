package main

import (
	"fmt"
	"strconv"
)

func main() {
	n := 10
	res := countAndSay(n)
	fmt.Println(res)
}

func countAndSay(n int) string {
	if n == 1 {
		return "1"
	} else if n == 2 {
		return "11"
	} else if n == 3 {
		return "21"
	} else if n == 4 {
		return "1211"
	} else {
		return getNewRes(countAndSay(n - 1))
	}
}

func getNewRes(str string) string {
	res := ""
	count := 1
	for i := 1; i < len(str); i++ {
		if str[i] != str[i-1] {
			res += strconv.Itoa(count)
			res += string(str[i-1])
			count = 1
		} else {
			count++
		}
	}
	res += strconv.Itoa(count)
	res += string(str[len(str)-1])
	return res
}
