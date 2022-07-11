/*
 * @lc app=leetcode.cn id=8 lang=rust
 *
 * [8] 字符串转换整数 (atoi)
 */

// @lc code=start
impl Solution {
    fn my_atoi(s: String) -> i32 {
        let s = s.trim();
        if s.len() == 0 {
            return 0;
        }
        let c: Vec<char> = s.chars().collect();
        let mut flag = 1;
        let mut index = 0;
        let mut res = 0;
        if c[0] == '-' {
            flag = -1;
            index += 1;
        }
        if c[0] == '+' {
            index += 1;
        }
        for i in index..s.len() {
            let tmp;
            if c[i].is_digit(10) {
                tmp = (c[i] as u8 - '0' as u8) as i32;
                if res > 214748364 || res == 214748364 && tmp > 7 {
                    return 2147483647;
                }
                if res < -214748364 || (res == -214748364 && tmp * flag < -8) {
                    return -2147483648;
                }
            } else {
                return res;
            }
            res = res * 10 + tmp * flag;
        }
        res
    }
}
// @lc code=end
