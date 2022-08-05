/*
 * @lc app=leetcode.cn id=35 lang=rust
 *
 * [35] 搜索插入位置
 */

// @lc code=start
impl Solution {
    pub fn search_insert(nums: Vec<i32>, target: i32) -> i32 {
        let mut left = 0;
        let mut right = nums.len() - 1;
        while left <= right {
            if target < nums[left] {
                return left as i32;
            } else if target > nums[right] {
                return right as i32 + 1;
            } else {
                let mid = (left + right) / 2;
                if target < nums[mid] {
                    right = mid - 1;
                } else if target > nums[mid] {
                    left = mid + 1;
                } else {
                    return mid as i32;
                }
            }
        }
        0
    }
}
// @lc code=end
