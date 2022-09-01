package main

type ListNode struct {
	Val  int
	Next *ListNode
}

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

func rotateRight1(head *ListNode, k int) *ListNode {
	if head == nil {
		return head
	}
	var myMap = make(map[int]*ListNode)
	n := 1
	tempListNode := head
	for tempListNode.Next != nil {
		myMap[n] = tempListNode
		tempListNode = tempListNode.Next
		n++
	}
	myMap[n] = tempListNode
	k = k % n
	if k == 0 || n == 1 {
		return head
	}
	tempListNode.Next = head
	myMap[n-k].Next = nil
	return myMap[n-k+1]
}
