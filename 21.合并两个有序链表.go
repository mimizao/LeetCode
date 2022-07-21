/*
 * @lc app=leetcode.cn id=21 lang=golang
 *
 * [21] 合并两个有序链表
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
func mergeTwoLists(list1 *ListNode, list2 *ListNode) *ListNode {
	if list1 == nil {
		return list2
	}
	if list2 == nil {
		return list1
	}
	headListNode := &ListNode{Val: 0, Next: nil}
	if list1.Val <= list2.Val {
		headListNode = list1
		list1 = list1.Next
	} else {
		headListNode = list2
		list2 = list2.Next
	}
	currentListNode := headListNode
	for {
		if list1 == nil {
			currentListNode.Next = list2
			break
		}
		if list2 == nil {
			currentListNode.Next = list1
			break
		}
		if list1.Val <= list2.Val {
			currentListNode.Next = list1
			currentListNode = list1
			list1 = list1.Next
		} else {
			currentListNode.Next = list2
			currentListNode = list2
			list2 = list2.Next
		}
	}
	return headListNode
}

// @lc code=end
