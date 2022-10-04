#include <iostream>
#include <vector>

using namespace std;

struct ListNode {
    int val;
    ListNode *next;

    ListNode() : val(0), next(nullptr) {}

    ListNode(int x) : val(x), next(nullptr) {}

    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class Solution {
public:
    ListNode *reverseBetween(ListNode *head, int left, int right) {
        if (left == right) {
            return head;
        }
        auto pre = new ListNode{0, nullptr};
        pre->next = head;
        auto cur = pre;
        for (int i = 1; i < left; i++) {
            cur = cur->next;
        }
        auto leftEndListNode = cur;
        cur = leftEndListNode->next;
        vector<ListNode *> listNodeList(right - left + 1, new ListNode{0, nullptr});
        for (int i = 0; i <= right - left; i++) {
            listNodeList[i] = cur;
            cur = cur->next;
        }
        listNodeList[0]->next = cur;
        for (int i = right - left; i > 0; i--) {
            listNodeList[i]->next = listNodeList[i - 1];
        }
        leftEndListNode->next = listNodeList[right - left];
        return pre->next;
    }
};

int main() {
    Solution solution;
    auto listNode5 = new ListNode{5, nullptr};
    auto listNode4 = new ListNode{4, listNode5};
    auto listNode3 = new ListNode{3, listNode4};
    auto listNode2 = new ListNode{2, listNode3};
    auto listNode1 = new ListNode{1, listNode2};
    auto res = solution.reverseBetween(listNode1, 2, 4);
    std::cout << res->val << std::endl;
    return 0;
}
