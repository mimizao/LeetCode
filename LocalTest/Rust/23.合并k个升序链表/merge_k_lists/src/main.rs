#[derive(PartialEq, Eq, Clone, Debug)]
pub struct ListNode {
    pub val: i32,
    pub next: Option<Box<ListNode>>,
}

impl ListNode {
    #[inline]
    fn new(val: i32) -> Self {
        ListNode { next: None, val }
    }
}

pub fn merge_k_lists(lists: Vec<Option<Box<ListNode>>>) -> Option<Box<ListNode>> {
    let len = lists.len();
    if len == 0 {
        return None;
    }
    return merge(&lists, 0, len);
}

pub fn merge(
    lists: &Vec<Option<Box<ListNode>>>,
    left: usize,
    right: usize,
) -> Option<Box<ListNode>> {
    if left == right {
        return lists[left].clone();
    }
    if left > right {
        return None;
    }
    let mid = (left + right) / 2;
    return merge_two_lists(merge(lists, left, mid), merge(lists, mid + 1, right));
}

pub fn merge_two_lists(
    list1: Option<Box<ListNode>>,
    list2: Option<Box<ListNode>>,
) -> Option<Box<ListNode>> {
    match (list1, list2) {
        (Some(n1), Some(n2)) => {
            if n1.val <= n2.val {
                Some(Box::new(ListNode {
                    val: n1.val,
                    next: merge_two_lists(n1.next, Some(n2)),
                }))
            } else {
                Some(Box::new(ListNode {
                    val: n2.val,
                    next: merge_two_lists(Some(n1), n2.next),
                }))
            }
        }
        (Some(n1), None) => Some(n1),
        (None, Some(n2)) => Some(n2),
        _ => None,
    }
}

fn main() {
    println!("Hello, world!");
}
