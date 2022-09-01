/*
 * @lc app=leetcode.cn id=61 lang=golang
 *
 * [61] 旋转链表
 */
package main

type ListNode struct {
	Val  int
	Next *ListNode
}

// @lc code=start
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func rotateRight(head *ListNode, k int) *ListNode {
	if head == nil {
		return head
	}
	n := 1
	tempListNode := head
	for tempListNode.Next != nil {
		tempListNode = tempListNode.Next
		n++
	}
	k = k % n
	if k == 0 || n == 1 {
		return head
	}
	tempListNode.Next = head
	tempListNode = head
	for i := 0; i < n-k-1; i++ {
		tempListNode = tempListNode.Next
	}
	resListNode := tempListNode.Next
	tempListNode.Next = nil
	return resListNode
}

// @lc code=end
