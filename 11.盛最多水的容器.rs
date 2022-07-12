/*
 * @lc app=leetcode.cn id=11 lang=rust
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
impl Solution {
    pub fn max_area(height: Vec<i32>) -> i32 {
        let mut res = 0;
        let mut left: usize = 0;
        let mut right = height.len() - 1;
        while left < right {
            let temp = (right - left) as i32 * Ord::min(height[left], height[right]);
            if temp > res {
                res = temp;
            }
            if height[left] <= height[right] {
                left += 1;
            } else {
                right -= 1;
            }
        }
        res
    }
}
// @lc code=end
