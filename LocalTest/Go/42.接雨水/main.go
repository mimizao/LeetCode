package main

import (
	"fmt"
)

func main() {
	height := []int{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}
	res := trap(height)
	res = trap1(height)
	fmt.Println(res)
}

func trap1(height []int) int {
	res := 0
	begin := 0
	end := len(height) - 1
	maxDiffer := 0
	for i := 0; i < len(height); i++ {
		if height[i] > maxDiffer {
			maxDiffer = height[i]
		}
	}

	for differ := 0; differ < maxDiffer-1; differ++ {
		begin, end = getNewBeginAndEnd(height, differ, begin, end)
		lineRes := 0
		for index := begin + 1; index < end; index++ {
			if height[index]-differ <= 0 {
				lineRes++
			}
		}
		res += lineRes
	}
	return res
}

func getNewBeginAndEnd(height []int, differ, oldBegin, oldEnd int) (int, int) {
	var newBegin, newEnd int
	for newBegin = oldBegin; newBegin < oldEnd; newBegin++ {
		if height[newBegin]-differ > 0 {
			break
		}
	}
	for newEnd = oldEnd; newEnd > oldBegin; newEnd-- {
		if height[newEnd]-differ > 0 {
			break
		}
	}
	return newBegin, newEnd
}

func trap(height []int) int {
	res := 0
	n := len(height)
	if n == 0 {
		return res
	}
	leftMax := make([]int, n)
	leftMax[0] = height[0]
	for i := 1; i < n; i++ {
		leftMax[i] = trapMax(leftMax[i-1], height[i])
	}
	rightMax := make([]int, n)
	rightMax[n-1] = height[n-1]
	for i := n - 2; i >= 0; i-- {
		rightMax[i] = trapMax(rightMax[i+1], height[i])
	}
	for i, h := range height {
		res += trapMin(leftMax[i], rightMax[i]) - h
	}
	return res
}

func trapMax(a, b int) int {
	if a < b {
		return b
	}
	return a
}

func trapMin(a, b int) int {
	if a < b {
		return a
	}
	return b
}
