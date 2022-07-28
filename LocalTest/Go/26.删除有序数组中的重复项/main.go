package main

import "fmt"

func main() {
	nums := []int{0, 0, 1, 1, 1, 2, 2, 3, 3, 4}
	res := removeDuplicates(nums)
	fmt.Println(res)
}

// @lc code=start
func removeDuplicates(nums []int) int {
	len := len(nums)
	if len <= 1 {
		return len
	}
	res := len
	left, right := 0, 1
	for right < len {
		if nums[left] >= nums[right] {
			if nums[left] == nums[len-1] {
				return right
			}
			index := right
			for index < len-1 {
				if nums[index] > nums[left] && nums[index] > nums[right] {
					break
				} else {
					index++
				}
			}
			nums[right] = nums[index]
			res--
		}
		left++
		right++
	}
	return res
}
