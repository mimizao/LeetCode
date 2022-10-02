#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;
class Solution {
public:
    vector<vector<int>> subsetsWithDup(vector<int> &nums) {
        auto len = nums.size();
        vector<vector<int>> res{{}};
        if (len == 0) {
            return res;
        }
        sort(nums.begin(), nums.end());
        vector<bool> used(len, false);
        vector<int> path;
        for (int i = 1; i <= len; i++) {
            dp(nums, res, used, path, 0, i, len);
        }
        return res;
    }

    void dp(vector<int> &nums, vector<vector<int>> &res, vector<bool> &used, vector<int> &path, int begin, int count,
            unsigned long long len) {
        if (path.size() == count) {
            vector<int> temp(path.size());
            copy(path.begin(), path.end(), temp.begin());
            res.push_back(temp);
            return;
        }
        for (int i = begin; i < len; i++) {
            if (used[i] || (count < len && i > 0 && nums[i] == nums[i - 1] && !used[i - 1])) {
                continue;
            }
            path.push_back(nums[i]);
            used[i] = true;
            dp(nums, res, used, path, i + 1, count, len);
            used[i] = false;
            path.pop_back();
        }
    }
};
int main() {
    std::cout << "Hello, World!" << std::endl;
    return 0;
}
