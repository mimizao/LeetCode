/*
 * @lc app=leetcode.cn id=80 lang=rust
 *
 * [80] 删除有序数组中的重复项 II
 */

// @lc code=start
impl Solution {
    pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
        let len = nums.len();
        if len <= 2 {
            return len as i32;
        }
        let mut index = len;
        let mut count = 1;
        let mut num = nums[0];
        let mut i = 1;
        while i < index {
            if nums[i] == num {
                if count < 2 {
                    count += 1;
                    i += 1;
                } else {
                    let mut temp_index = i;
                    while temp_index < index && nums[temp_index] == num {
                        temp_index += 1;
                    }
                    for j in 0..len - temp_index {
                        nums[i + j] = nums[temp_index + j];
                    }
                    index = i + index - temp_index;
                    if i + 1 < index {
                        num = nums[i];
                    } else {
                        return index as i32;
                    }
                    count = 1;
                    i += 1;
                }
            } else {
                num = nums[i];
                count = 1;
                i += 1;
            }
        }
        index as i32
    }
}
// @lc code=end

