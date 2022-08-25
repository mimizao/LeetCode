package main

import (
	"fmt"
)

func main() {
	matrix := [][]int{{1, 2, 3}, {4, 5, 6}, {7, 8, 9}, {7, 8, 9}, {7, 8, 9}, {7, 8, 9}, {7, 8, 9}}
	res := spiralOrder1(matrix)
	fmt.Println(res)
}

func spiralOrder(matrix [][]int) []int {
	var res []int
	m := len(matrix)
	n := len(matrix[0])
	up, right, down, left, count := 0, 0, 0, 0, 0
	maxCount := 0
	if m <= n {
		maxCount = 2*m - 1
	} else {
		maxCount = 2 * n
	}
	for {
		res = append(res, matrix[up][left:n-right]...)
		up++
		count++
		if count >= maxCount {
			break
		}
		for j := up; j < m-down; j++ {
			res = append(res, matrix[j][n-right-1])
		}
		right++
		count++
		if count >= maxCount {
			break
		}
		res = append(res, reverse(matrix[m-down-1][left:n-right])...)
		down++
		count++
		if count >= maxCount {
			break
		}
		for j := m - down - 1; j >= up; j-- {
			res = append(res, matrix[j][left])
		}
		left++
		count++
		if count >= maxCount {
			break
		}
	}
	return res
}
func spiralOrder1(matrix [][]int) []int {
	var res []int
	m := len(matrix)
	n := len(matrix[0])
	up, right, down, left := 0, 0, 0, 0
	maxCount := 0
	if m <= n {
		maxCount = 2*m - 1
	} else {
		maxCount = 2 * n
	}
	for count := 0; count < maxCount; count++ {
		switch count % 4 {
		case 0:
			res = append(res, matrix[up][left:n-right]...)
			up++
		case 1:
			for j := up; j < m-down; j++ {
				res = append(res, matrix[j][n-right-1])
			}
			right++
		case 2:
			res = append(res, reverse(matrix[m-down-1][left:n-right])...)
			down++
		case 3:
			for j := m - down - 1; j >= up; j-- {
				res = append(res, matrix[j][left])
			}
			left++
		}
	}
	return res
}
func reverse(nums []int) []int {
	for i, j := 0, len(nums)-1; i < j; i, j = i+1, j-1 {
		nums[i], nums[j] = nums[j], nums[i]
	}
	return nums
}
