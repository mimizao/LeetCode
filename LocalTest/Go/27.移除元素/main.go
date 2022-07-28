package main

import (
	"fmt"
	"sort"
)

func main() {
	nums := []int{0, 2, 2, 1, 2, 1, 2, 2, 4}
	val := 2
	res := removeElement(nums, val)
	fmt.Println(res)
}

func removeElement(nums []int, val int) int {
	len := len(nums)
	if len == 0 {
		return len
	}
	sort.Ints(nums)
	count := 0
	for i := 0; i < len; i++ {
		if nums[i] == val {
			count++
			if nums[i] == nums[len-count] {
				return i
			}
			if i < len-count {
				nums[i] = nums[len-count]
			} else {
				return len - count
			}
		} else if nums[i] > val {
			break
		}
	}
	return len - count
}
