/*
 * @lc app=leetcode.cn id=86 lang=cpp
 *
 * [86] 分隔链表
 */
struct ListNode {
    int val;
    ListNode *next;

    ListNode() : val(0), next(nullptr) {}

    ListNode(int x) : val(x), next(nullptr) {}

    ListNode(int x, ListNode *next) : val(x), next(next) {}
};
// @lc code=start
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
public:
    ListNode *partition(ListNode *head, int x) {
        if (head == nullptr || head->next == nullptr) {
            return head;
        }
        auto pre = new ListNode{101, nullptr};
        ListNode *leftHead = pre;
        ListNode *rightHead = pre;
        ListNode *curLeft = pre;
        ListNode *curRight = pre;
        ListNode *cur = head;
        while (cur != nullptr) {
            if (cur->val < x) {
                if (leftHead->val == 101) {
                    leftHead = cur;
                    curLeft = leftHead;
                } else {
                    curLeft->next = cur;
                    curLeft = curLeft->next;
                }
            } else {
                if (rightHead->val == 101) {
                    rightHead = cur;
                    curRight = rightHead;
                } else {
                    curRight->next = cur;
                    curRight = curRight->next;
                }
            }
            if (cur->next != nullptr) {
                cur = cur->next;
            } else {
                break;
            }
        }
        if (leftHead->val == 101) {
            return rightHead;
        }
        if (rightHead->val == 101) {
            return leftHead;
        }
        curRight->next = nullptr;
        curLeft->next = rightHead;
        return leftHead;
    }
};
// @lc code=end

