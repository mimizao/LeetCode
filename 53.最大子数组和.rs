/*
 * @lc app=leetcode.cn id=53 lang=rust
 *
 * [53] 最大子数组和
 */

// @lc code=start
impl Solution {
    pub fn max_sub_array(nums: Vec<i32>) -> i32 {
        let mut pre = 0;
        let mut res = nums[0];
        for v in nums {
            pre = max(pre + v, v);
            res = max(res, pre);
        }
        res
    }
}
// @lc code=end

