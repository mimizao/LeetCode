/*
 * @lc app=leetcode.cn id=47 lang=rust
 *
 * [47] 全排列 II
 */

// @lc code=start
impl Solution {
    pub fn permute_unique(nums: Vec<i32>) -> Vec<Vec<i32>> {
        let mut res = vec![];
        let len = nums.len();
        if len == 0 {
            return res;
        }
        let mut used = vec![false; len];
        let mut path = vec![];
        let mut nums = nums;
        nums.sort_unstable();
        Solution::dfs(&nums, &mut path, &mut used, &mut res);
        res
    }

    pub fn dfs(nums: &Vec<i32>, path: &mut Vec<i32>, used: &mut Vec<bool>, res: &mut Vec<Vec<i32>>) {
        if path.len() == nums.len() {
            res.push(path.clone());
            return;
        }
        for i in 0..nums.len() {
            if used[i] {
                continue;
            }
            if i > 0 && nums[i] == nums[i - 1] && !used[i - 1] {
                continue;
            }
            path.push(nums[i]);
            used[i] = true;
            Solution::dfs(&nums, path, used, res);
            used[i] = false;
            path.pop();
        }
    }
}
// @lc code=end

