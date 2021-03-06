/*
 * @lc app=leetcode.cn id=26 lang=rust
 *
 * [26] 删除有序数组中的重复项
 */

// @lc code=start
impl Solution {
    pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
        let len = nums.len();
        if len <= 1 {
            return len as i32;
        }
        let mut left = 0;
        let mut right = 1;
        let mut res = len;
        while right < len {
            if nums[left] >= nums[right] {
                if nums[left] == nums[len - 1] {
                    return right as i32;
                }
                let mut index = right;
                while right < len - 1 {
                    if nums[index] > nums[left] && nums[index] > nums[right] {
                        break;
                    } else {
                        index += 1;
                    }
                }
                nums[right] = nums[index];
                res -= 1;
            }
            left += 1;
            right += 1;
        }
        res as i32
    }
    pub fn remove_duplicates1(nums: &mut Vec<i32>) -> i32 {
        let len = nums.len();
        if len <= 1 {
            return len as i32;
        }
        let mut slow = 1;
        let mut fast = 1;
        while fast < len {
            if nums[fast] != nums[fast - 1] {
                nums[slow] = nums[fast];
                slow += 1;
            }
            fast += 1;
        }
        return slow as i32;
    }
}
// @lc code=end
