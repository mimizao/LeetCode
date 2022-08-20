#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    static int trap(vector<int> &height) {
        int res = 0;
        int len = height.size();
        if (len == 0) {
            return res;
        }

        vector<int> leftMax(len);
        leftMax[0] = height[0];
        for (int i = 1; i < len; ++i) {
            leftMax[i] = max(leftMax[i - 1], height[i]);
        }

        vector<int> rightMax(len);
        rightMax[len - 1] = height[len - 1];
        for (int i = len - 2; i >= 0; i--) {
            rightMax[i] = max(rightMax[i + 1], height[i]);
        }

        for (int i = 0; i < len; i++) {
            res += min(leftMax[i], rightMax[i]) - height[i];
        }

        return res;
    }
};

int main() {
    vector<int> height = {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
    int res = Solution::trap(height);
    std::cout << res << std::endl;
    return 0;
}
