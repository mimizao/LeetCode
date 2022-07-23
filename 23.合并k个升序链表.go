/*
 * @lc app=leetcode.cn id=23 lang=golang
 *
 * [23] 合并K个升序链表
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
func mergeKLists(lists []*ListNode) *ListNode {
	return merge(lists, 0, len(lists)-1)
}

func merge(lists []*ListNode, left, right int) *ListNode {
	if left == right {
		return lists[left]
	}
	if left > right {
		return nil
	}
	mid := (left + right) / 2
	return newMergeTwoLists(merge(lists, left, mid), merge(lists, mid+1, right))
}

// @lc code=end

func mergeKLists1(lists []*ListNode) *ListNode {
	if len(lists) == 0 {
		return nil
	}
	res := lists[0]
	for i := 1; i < len(lists); i++ {
		res = newMergeTwoLists(res, lists[i])
	}
	return res
}

func newMergeTwoLists(list1 *ListNode, list2 *ListNode) *ListNode {
	if list1 == nil {
		return list2
	} else if list2 == nil {
		return list1
	} else if list1.Val <= list2.Val {
		list1.Next = newMergeTwoLists(list1.Next, list2)
		return list1
	} else {
		list2.Next = newMergeTwoLists(list1, list2.Next)
		return list2
	}
}

func mergeKLists2(lists []*ListNode) *ListNode {
	if len(lists) == 0 {
		return nil
	}
	if len(lists) == 1 {
		return lists[0]
	}
	var res *ListNode
	var max = 10001
	var index = 0
	for i := 0; i < len(lists); i++ {
		if lists[i] != nil && lists[i].Val < max {
			index = i
			max = lists[i].Val
		}
	}
	res = lists[index]
	if lists[index] != nil {
		lists[index] = lists[index].Next
		res.Next = mergeKLists(lists)
	}
	return res
}
