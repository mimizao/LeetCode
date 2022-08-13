/*
 * @lc app=leetcode.cn id=42 lang=rust
 *
 * [42] 接雨水
 */

// @lc code=start
impl Solution {
    pub fn trap(height: Vec<i32>) -> i32 {
        let mut res = 0;
        let len = height.len();
        if len == 0 {
            return res;
        }
    
        let mut left_max = vec![0; height.len()];
        left_max[0] = height[0];
        for i in 1..len {
            left_max[i] = Ord::max(left_max[i - 1], height[i]);
        }
    
        let mut right_max = vec![0; height.len()];
        right_max[len - 1] = height[len - 1];
        let mut temp_right = len as i32 - 2;
        while temp_right >= 0 {
            right_max[temp_right as usize] = Ord::max(
                right_max[temp_right as usize + 1],
                height[temp_right as usize],
            );
            temp_right -= 1;
        }
        for i in 0..len {
            res += Ord::min(left_max[i], right_max[i]) - height[i];
        }
        res
    }
}
// @lc code=end

