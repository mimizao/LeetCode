/*
 * @lc app=leetcode.cn id=1 lang=rust
 *
 * [1] 两数之和
 */

// @lc code=start
use std::collections::HashMap;
impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut map = HashMap::new();
        for i in 0..nums.len() {
            if let Some(value) = map.get(&(target - nums[i])) {
                return vec![i as i32, *value as i32];
            }
            map.insert(nums[i], i);
        }
        Vec::new()
    }
}
// @lc code=end
