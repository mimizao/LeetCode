using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
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
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null) return head;
        ListNode tempHead = head;
        ListNode tempHeadNext = head.next;
        ListNode tempNextNext = head.next.next;
        head = tempHeadNext;
        head.next = tempHead;
        head.next.next = SwapPairs(tempNextNext);
        return head;
    }
}
// @lc code=end

