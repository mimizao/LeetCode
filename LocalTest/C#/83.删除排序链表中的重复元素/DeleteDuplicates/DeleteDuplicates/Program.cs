// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class ListNode
{
    public ListNode next;
    public int val;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


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