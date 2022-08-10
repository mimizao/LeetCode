/*
 * @lc app=leetcode.cn id=41 lang=rust
 *
 * [41] 缺失的第一个正数
 */

// @lc code=start
impl Solution {
    pub fn first_missing_positive(nums: Vec<i32>) -> i32 {
        let mut nums = nums;
        let len = nums.len();
        if len == 0 {
            return 0;
        }
        for i in 0..len {
            if nums[i] <= 0 {
                nums[i] = len as i32 + 1;
            }
        }
        for i in 0..len {
            let num = i32::abs(nums[i]);
            if num as usize <= len {
                nums[num as usize - 1] = -i32::abs(nums[num as usize - 1])
            }
        }
        for i in 0..len {
            if nums[i] >= 0 {
                return i as i32 + 1;
            }
        }
        len as i32 + 1
    }
}
// @lc code=end

