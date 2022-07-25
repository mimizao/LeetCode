/*
 * @lc app=leetcode.cn id=24 lang=golang
 *
 * [24] 两两交换链表中的节点
 */
package main

// @lc code=start
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func swapPairs(head *ListNode) *ListNode {
	if head == nil || head.Next == nil {
		return head
	}
	tempHead := head
	tempHeadNext := head.Next
	tempNextNext := head.Next.Next
	head = tempHeadNext
	head.Next = tempHead
	head.Next.Next = swapPairs(tempNextNext)
	return head
}

// @lc code=end
