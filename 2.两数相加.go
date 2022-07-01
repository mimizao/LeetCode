/*
 * @lc app=leetcode.cn id=2 lang=golang
 *
 * [2] 两数相加
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */

package main

type ListNode struct {
	Val  int
	Next *ListNode
}

func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	l := addTwoNumbersWithFlag(l1, l2, 0)
	return l
}

func addTwoNumbersWithFlag(l1 *ListNode, l2 *ListNode, flag int) *ListNode {
	if l1 == nil && l2 == nil && flag == 0 {
		return nil
	}
	if l1 == nil && l2 == nil && flag == 1 {
		return &ListNode{Val: 1, Next: nil}
	}
	val, tempFlag := getValAndFlag(l1.Val, l2.Val, flag)
	flag = tempFlag
	if l1.Next != nil && l2.Next != nil {
		l1 = l1.Next
		l2 = l2.Next
	} else if l1.Next == nil && l2.Next != nil {
		l1 = &ListNode{Val: 0, Next: nil}
		l2 = l2.Next
	} else if l1.Next != nil && l2.Next == nil {
		l1 = l1.Next
		l2 = &ListNode{Val: 0, Next: nil}
	} else {
		l1 = nil
		l2 = nil
	}
	l := &ListNode{Val: val, Next: addTwoNumbersWithFlag(l1, l2, flag)}
	return l
}

func getValAndFlag(val1, val2, flag int) (int, int) {
	if val := val1 + val2 + flag; val >= 10 {
		return val - 10, 1
	} else {
		return val, 0
	}
}

// @lc code=end
