/*
 * @lc app=leetcode.cn id=82 lang=golang
 *
 * [82] 删除排序链表中的重复元素 II
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
func deleteDuplicates(head *ListNode) *ListNode {
	if head == nil || head.Next == nil {
		return head
	}
	pre := &ListNode{
		Val:  0,
		Next: head,
	}
	cur := pre
	for cur.Next != nil && cur.Next.Next != nil {
		if cur.Next.Val == cur.Next.Next.Val {
			curNextVal := cur.Next.Val
			for cur.Next != nil && cur.Next.Val == curNextVal {
				cur.Next = cur.Next.Next
			}
		} else {
			cur = cur.Next
		}
	}
	return pre.Next
}

// @lc code=end
