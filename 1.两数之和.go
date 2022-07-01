/*
 * @lc app=leetcode.cn id=1 lang=golang
 *
 * [1] 两数之和
 */
package main

// @lc code=start
func twoSum(nums []int, target int) []int {
	if len(nums) <= 2 {
		return []int{0, 1}
	}
	var numsMap = make(map[int]int)
	for i, v := range nums {
		temp := target - v
		if index, ok := numsMap[temp]; ok && index != i {
			return []int{index, i}
		} else {
			numsMap[v] = i
		}
	}
	return []int{0, 0}
}

// @lc code=end
