/*
 * @lc app=leetcode.cn id=7 lang=rust
 *
 * [7] 整数反转
 */

// @lc code=start
impl Solution {
    pub fn reverse(x: i32) -> i32 {
        let mut res: i32 = 0;
        let mut new_x = x;
        while new_x != 0 {
            let tmp = new_x % 10;
            if (res > 214748364) || (res == 214748364 && tmp > 7) {
                return 0;
            }
            if (res < -214748364) || (res == -214748364 && tmp < -8) {
                return 0;
            }
            res = res * 10 + tmp;
            new_x /= 10;
        }
        res
    }
}
// @lc code=end
