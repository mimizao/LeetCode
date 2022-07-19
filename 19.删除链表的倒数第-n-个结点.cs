using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=19 lang=csharp
 *
 * [19] 删除链表的倒数第 N 个结点
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
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        int len = 1;
        ListNode currentListNode = head;
        for (; currentListNode.next != null; currentListNode = currentListNode.next)
        {
            len++;
        }
        if (len < n) { return head; }
        if (len == n) { return head.next; }
        currentListNode = head;
        for (int i = 0; i < len - n - 1; i++)
        {
            currentListNode = currentListNode.next;
        }
        ListNode tempListNode = currentListNode.next;
        currentListNode.next = tempListNode.next;
        return head;
    }
}
// @lc code=end

