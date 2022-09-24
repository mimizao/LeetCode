/*
 * @lc app=leetcode.cn id=83 lang=csharp
 *
 * [83] 删除排序链表中的重复元素
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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head?.next == null)
        {
            return head;
        }
        ListNode cur = head;
        int tempVal = cur.val;
        while (cur.next != null)
        {
            while (tempVal == cur.next.val)
            {
                if (cur.next.next != null)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur.next = null;
                    return head;
                }
            }
            cur = cur.next;
            tempVal = cur.val;
        }
        return head;
    }
}
// @lc code=end

