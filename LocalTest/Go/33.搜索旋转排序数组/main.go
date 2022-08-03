package main

import "fmt"

func main() {
	nums := []int{3, 5, 1}
	target := 1
	res := search(nums, target)
	fmt.Println(res)
}

func search(nums []int, target int) int {
	len := len(nums)
	if len == 1 {
		if target == nums[0] {
			return 0
		} else {
			return -1
		}
	}
	left := 0
	right := len - 1
	for left <= right {
		mid := (left + right) / 2
		if nums[mid] == target {
			return mid
		}
		if nums[0] <= nums[mid] {
			if nums[0] <= target && target < nums[mid] {
				right = mid - 1
			} else {
				left = mid + 1
			}
		} else {
			if nums[mid] < target && target <= nums[len-1] {
				left = mid + 1
			} else {
				right = mid - 1
			}
		}
	}
	return -1
}
