using System.IO;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=21 lang=csharp
 *
 * [21] 合并两个有序链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode MergeTwoLists1(ListNode list1, ListNode list2)
    {
        if (list1 == null)
        {
            return list2;
        }
        if (list2 == null)
        {
            return list1;
        }
        ListNode headListNode = new ListNode();
        if (list1.val <= list2.val)
        {
            headListNode = list1;
            list1 = list1.next;
        }
        else
        {
            headListNode = list2;
            list2 = list2.next;
        }
        ListNode currentListNode = headListNode;
        while (true)
        {
            if (list1 == null)
            {
                currentListNode.next = list2;
                break;
            }
            if (list2 == null)
            {
                currentListNode.next = list1;
                break;
            }
            if (list1.val <= list2.val)
            {
                currentListNode.next = list1;
                currentListNode = list1;
                list1 = list1.next;
            }
            else
            {
                currentListNode.next = list2;
                currentListNode = list2;
                list2 = list2.next;
            }
        }
        return headListNode;
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
        {
            return list2;
        }
        else if (list2 == null)
        {
            return list1;
        }
        else if (list1.val <= list2.val)
        {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}
// @lc code=end

