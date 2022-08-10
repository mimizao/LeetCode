package main

import "fmt"

func main() {
	nums := []int{1, 2, 0}
	res := firstMissingPositive(nums)
	fmt.Println(res)
}

func firstMissingPositive(nums []int) int {
	n := len(nums)
	for i := 0; i < n; i++ {
		if nums[i] <= 0 {
			nums[i] = n + 1
		}
	}
	for i := 0; i < n; i++ {
		num := myNewAbs(nums[i])
		if num <= n {
			nums[num-1] = -myNewAbs(nums[num-1])
		}
	}
	for i := 0; i < n; i++ {
		if nums[i] > 0 {
			return i + 1
		}
	}
	return n + 1
}

func myNewAbs(x int) int {
	if x < 0 {
		return -x
	}
	return x
}
