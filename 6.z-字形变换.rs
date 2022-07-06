/*
 * @lc app=leetcode.cn id=6 lang=rust
 *
 * [6] Z 字形变换
 */

// @lc code=start
impl Solution {
    pub fn convert(s: String, num_rows: i32) -> String {
        let num_rows = num_rows as usize;
        let len = s.len();
        if len < num_rows || num_rows == 1 {
            return s;
        }
        let mut res = String::from("");
        let t = 2 * num_rows - 2;
        for i in 0..num_rows {
            let mut j = 0;
            while (j + i < len) {
                res += s[i + j];
                if i > 0 && i < num_rows - 1 && j + t - i < len {
                    res += s[j + t - i];
                }
                j += t;
            }
        }
        return res;
    }
}
// @lc code=end
