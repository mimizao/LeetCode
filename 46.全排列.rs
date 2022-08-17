/*
 * @lc app=leetcode.cn id=46 lang=rust
 *
 * [46] 全排列
 */

// @lc code=start
impl Solution {
    pub fn permute(nums: Vec<i32>) -> Vec<Vec<i32>> {
        let mut res = vec![];
        let len = nums.len();
        if len == 0 {
            return res;
        }
        let mut used = vec![false; len];
        let mut path = vec![];
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
            path.push(nums[i]);
            used[i] = true;
            Solution::dfs(&nums, path, used, res);
            used[i] = false;
            path.pop();
        }
    }
}
// @lc code=end

