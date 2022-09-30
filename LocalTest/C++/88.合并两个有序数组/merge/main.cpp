#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    void merge(vector<int> &nums1, int m, vector<int> &nums2, int n) {
        for (int i = m, j = 0; i < nums1.size(); i++, j++) {
            nums1[i] = nums2[j];
        }
        sort(nums1.begin(), nums1.end());
    }
};

int main() {
    Solution solution;
    vector<int> num1{1, 2, 3, 0, 0, 0};
    vector<int> num2{2, 5, 6};
    solution.merge(num1, 3, num2, 3);
    std::cout << "Hello, World!" << std::endl;
    return 0;
}
