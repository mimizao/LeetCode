using System.Linq.Expressions;
using System.Globalization;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=25 lang=csharp
 *
 * [25] K 个一组翻转链表
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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode hair = new ListNode() { next = head };
        ListNode pre = hair;
        while (head != null)
        {
            ListNode tail = pre;
            for (int i = 0; i < k; i++)
            {
                tail = tail.next;
                if (tail == null)
                {
                    return hair.next;
                }
            }
            ListNode nex = tail.next;
            ListNode[] temp = MyReverse(head,tail);
            head = temp[0];
            tail = temp[1];
            pre.next = head;
            tail.next =nex;
            pre = tail;
            head = tail.next;
        }
        return hair.next;
    }

    public ListNode[] MyReverse(ListNode head, ListNode tail)
    {
        ListNode prev = tail.next;
        ListNode p = head;
        while (prev != tail)
        {
            ListNode nex = p.next;
            p.next = prev;
            prev = p;
            p=nex;
        }
        return new ListNode[]{tail,head};
    }
}
// @lc code=end

