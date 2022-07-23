using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并K个升序链表
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

    public ListNode MergeKLists(ListNode[] lists)
    {
        return Merge(lists,0,lists.Length-1);
    }

    ListNode Merge(ListNode[] lists, int left, int right)
    {
        if (left == right) return lists[left];
        if (left > right) return null;
        int mid = (left + right) / 2;
        return MergeTwoLists(Merge(lists,left,mid),Merge(lists,mid+1,right));
    }

    ListNode MergeTwoLists(ListNode list1, ListNode list2)
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

    public ListNode MergeKLists1(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        ListNode res = lists[0];
        for (int i = 1; i < lists.Length; i++)
        {
            res = MergeTwoLists(res, lists[i]);
        }
        return res;
    }

    public ListNode MergeKLists2(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        if (lists.Length == 1) return lists[0];
        ListNode res = new ListNode();
        int max = 10001;
        int index = 0;
        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null && lists[i].val < max)
            {
                index = i;
                max = lists[i].val;
            }
        }
        res = lists[index];
        if (lists[index] != null)
        {
            lists[index] = lists[index].next;
            res.next = MergeKLists2(lists);
        }
        return res;
    }
}
// @lc code=end

