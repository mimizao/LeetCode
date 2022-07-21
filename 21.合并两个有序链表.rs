/*
 * @lc app=leetcode.cn id=21 lang=rust
 *
 * [21] 合并两个有序链表
 */

// @lc code=start
// Definition for singly-linked list.
// #[derive(PartialEq, Eq, Clone, Debug)]
// pub struct ListNode {
//   pub val: i32,
//   pub next: Option<Box<ListNode>>
// }
//
// impl ListNode {
//   #[inline]
//   fn new(val: i32) -> Self {
//     ListNode {
//       next: None,
//       val
//     }
//   }
// }
impl Solution {
    pub fn merge_two_lists(
        list1: Option<Box<ListNode>>,
        list2: Option<Box<ListNode>>,
    ) -> Option<Box<ListNode>> {
        match (list1, list2) {
            (Some(n1), Some(n2)) => {
                if n1.val <= n2.val {
                    Some(Box::new(ListNode {
                        val: n1.val,
                        next: Solution::merge_two_lists(n1.next, Some(n2)),
                    }))
                } else {
                    Some(Box::new(ListNode {
                        val: n2.val,
                        next: Solution::merge_two_lists(Some(n1), n2.next),
                    }))
                }
            }
            (Some(n1), None) => Some(n1),
            (None, Some(n2)) => Some(n2),
            _ => None,
        }
    }
}
// @lc code=end
