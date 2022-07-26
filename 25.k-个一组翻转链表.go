/*
 * @lc app=leetcode.cn id=25 lang=golang
 *
 * [25] K 个一组翻转链表
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
func reverseKGroup1(head *ListNode, k int) *ListNode {
	if k <= 1 {
		return head
	}
	if !compareKGroup(head, k) {
		return head
	}
	for i := 0; i < k-1; i++ {
		head = swapPairsInter(head, k-i)
	}
	theKthListNode := getKthListNode(head, k)
	theKthListNode.Next = reverseKGroup1(theKthListNode.Next, k)
	return head
}

// 交换的入口
func swapPairsInter(head *ListNode, k int) *ListNode {
	if k <= 1 {
		return head
	}
	if !compareKGroup(head, k) {
		return head
	}
	head = swapPairsListNode(head)
	head.Next = swapPairsInter(head.Next, k-1)
	return head
}

// 交换相邻节点
func swapPairsListNode(leftListNode *ListNode) *ListNode {
	rightListNode := leftListNode.Next
	if leftListNode == nil || rightListNode == nil {
		return leftListNode
	}
	tempListNode1 := leftListNode
	tempListNode2 := rightListNode.Next
	leftListNode = rightListNode
	rightListNode = tempListNode1
	leftListNode.Next = rightListNode
	rightListNode.Next = tempListNode2
	return leftListNode
}

// 判断当前剩余节点数量是否满足K
func compareKGroup(head *ListNode, k int) bool {
	tempListNode := head
	for {
		if tempListNode != nil {
			k--
			if k <= 0 {
				return true
			}
			tempListNode = tempListNode.Next
		} else {
			return false
		}
	}
}

// 得到交换后的最后一个节点
func getKthListNode(head *ListNode, k int) *ListNode {
	tempListNode := head
	for i := 0; i < k-1; i++ {
		tempListNode = tempListNode.Next
	}
	return tempListNode
}

// @lc code=end
