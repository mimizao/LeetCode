#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    vector<vector<int>> permute(vector<int> &nums) {
        vector<vector<int>> res;
        int len = nums.size();
        if (len == 0) {
            return res;
        }
        vector<int> path;
        vector<bool> used;
        dfs(nums, path, used, res);
        return res;
    }

    void dfs(vector<int> &nums, vector<int> &path, vector<bool> &used, vector<vector<int>> &res) {
        if (path.size() == nums.size()) {
            res.push_back(path);
            return;
        }
        for (int i = 0; i < nums.size(); i++) {
            if (used[i])continue;
            path.push_back(nums[i]);
            used[i] = true;
            dfs(nums, path, used, res);
            used[i] = false;
            path.pop_back();
        }
    }
};

int main() {
    Solution solution;
    vector<int> nums = {1, 2, 3};
    auto res = solution.permute(nums);
    return 0;
}
