/*
 * @lc app=leetcode.cn id=46 lang=cpp
 *
 * [46] 全排列
 */
#include <vector>
using namespace std;
// @lc code=start
class Solution {
public:
    vector<vector<int>> permute(vector<int> &nums) {
        vector<vector<int>> res;
        int len = nums.size();
        if (len == 0) {
            return res;
        }
        vector<int> path;
        vector<bool> used(nums.size(), false);
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
// @lc code=end

