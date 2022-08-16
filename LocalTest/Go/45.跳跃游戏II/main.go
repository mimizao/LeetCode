package main

import "fmt"

func main() {
	nums := []int{1, 2, 1, 1, 1}
	res := jump(nums)
	fmt.Println(res)
}

func jump(nums []int) int {
	n := len(nums)
	var count int
	begin := 0
	for begin <= n-1 {
		if begin == n-1 {
			break
		} else if begin+nums[begin] >= n-1 {
			count++
			break
		} else {
			temp := 0
			newBegin := begin
			for i := 1; i <= nums[begin]; i++ {
				if temp <= nums[begin+i]+i {
					temp = nums[begin+i] + i
					newBegin = begin + i
				}
			}
			begin = newBegin
			count++
		}
	}
	return count
}
