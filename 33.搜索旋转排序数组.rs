/*
 * @lc app=leetcode.cn id=33 lang=rust
 *
 * [33] 搜索旋转排序数组
 */

// @lc code=start
impl Solution {
    pub fn search(nums: Vec<i32>, target: i32) -> i32 {
        let len = nums.len();
        if len == 1 {
            if nums[0] == target {
                return 0;
            } else {
                return -1;
            }
        }
        let mut left = 0;
        let mut right = len - 1;
        while left <= right {
            let mid = (left + right) / 2;
            if nums[mid] == target {
                return mid as i32;
            }
            if nums[0] <= nums[mid] {
                if nums[0] <= target && target <= nums[mid] {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            } else {
                if nums[mid] <= target && target <= nums[len - 1] {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }
        -1
    }
}
// @lc code=end

