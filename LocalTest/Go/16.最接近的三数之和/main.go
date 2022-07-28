package main

import (
	"fmt"
	"math"
	"sort"
)

func main() {
	target := 100
	nums := []int{1, 1, 1, 0}
	res := threeSumClosest(nums, target)
	fmt.Println(res)
}

func threeSumClosest(nums []int, target int) int {
	sort.Ints(nums)
	res := nums[0] + nums[1] + nums[2]
	difference := int(math.Abs((float64)(res - target)))
	for first := 0; first < len(nums)-2; first++ {

		second := first + 1
		third := len(nums) - 1
		for second < third {
			newDifference := int(math.Abs((float64)(nums[first] + nums[second] + nums[third] - target)))
			if newDifference == 0 {
				return target
			}
			if newDifference < difference {
				difference = newDifference
				res = nums[first] + nums[second] + nums[third]
			}
			if target > nums[first]+nums[second]+nums[third] {
				second++
				for second < third && nums[second] == nums[second+1] {
					second++
				}
			} else {
				third--
				for second < third && nums[third] == nums[third-1] {
					third--
				}
			}
		}
	}
	return res
}
