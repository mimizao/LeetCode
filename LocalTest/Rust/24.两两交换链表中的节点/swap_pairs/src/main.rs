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

pub fn swap_pairs(head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
    if head == None || head.unwrap().next == None {
        return head.clone();
    }
    let temp_head = head.clone();
    let temp_head_next = temp_head.clone();
    let temp_next_next = temp_head_next.unwrap().next.clone();

    head
}

fn main() {
    println!("Hello, world!");
}
