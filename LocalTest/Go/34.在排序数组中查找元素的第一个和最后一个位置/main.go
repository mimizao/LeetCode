package main

import "fmt"

func main() {
	nums := []int{1}
	target := 1
	res := searchRange(nums, target)
	fmt.Println(res)
}

func searchRange(nums []int, target int) []int {
	res := []int{-1, -1}
	left := 0
	right := len(nums) - 1
	for left <= right {
		mid := (left + right) / 2
		if nums[mid] == target {
			begin, end := mid, mid
			for begin > 0 && nums[begin-1] == target {
				begin--
			}
			for end < len(nums)-1 && nums[end+1] == target {
				end++
			}
			res[0] = begin
			res[1] = end
			return res
		} else if nums[mid] < target {
			left = mid + 1
		} else {
			right = mid - 1
		}
	}
	return res
}
