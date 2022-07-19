/*
 * @lc app=leetcode.cn id=18 lang=rust
 *
 * [18] 四数之和
 */

// @lc code=start
impl Solution {
    pub fn four_sum(nums: Vec<i32>, target: i32) -> Vec<Vec<i32>> {
        let len = nums.len();
        if len < 4 {
            return vec![];
        }
        let mut res = vec![];
        let mut nums = nums;
        nums.sort_unstable();
        for first in 0..len - 3 {
            if nums[first] as i64
                + nums[first + 1] as i64
                + nums[first + 2] as i64
                + nums[first + 3] as i64
                > target as i64
            {
                return res;
            }
            if first > 0 && nums[first] == nums[first - 1]
                || (nums[first] as i64
                    + nums[len - 1] as i64
                    + nums[len - 2] as i64
                    + nums[len - 3] as i64)
                    < (target as i64)
            {
                continue;
            }
            for second in first + 1..len - 2 {
                if nums[first] as i64
                    + nums[second] as i64
                    + nums[second + 1] as i64
                    + nums[second + 2] as i64
                    > target as i64
                {
                    break;
                }
                if second > first + 1 && nums[second] == nums[second - 1]
                    || (nums[first] as i64
                        + nums[second] as i64
                        + nums[len - 1] as i64
                        + nums[len - 2] as i64)
                        < (target as i64)
                {
                    continue;
                }
                let mut left = second + 1;
                let mut right = len - 1;
                while left < right {
                    match nums[first] as i64
                        + nums[second] as i64
                        + nums[left] as i64
                        + nums[right] as i64
                        - target as i64
                    {
                        0 => {
                            res.push(vec![nums[first], nums[second], nums[left], nums[right]]);
                            left += 1;
                            while left < right && nums[left] == nums[left - 1] {
                                left += 1;
                            }
                            right -= 1;
                            while left < right && nums[right] == nums[right + 1] {
                                right -= 1;
                            }
                        }
                        s if s < 0 => {
                            left += 1;
                        }
                        _ => {
                            right -= 1;
                        }
                    }
                }
            }
        }
        res
    }
}
// @lc code=end
