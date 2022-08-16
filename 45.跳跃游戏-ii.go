/*
 * @lc app=leetcode.cn id=45 lang=golang
 *
 * [45] 跳跃游戏 II
 */
package main

// @lc code=start

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

// @lc code=end
