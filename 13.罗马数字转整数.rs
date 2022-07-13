/*
 * @lc app=leetcode.cn id=13 lang=rust
 *
 * [13] 罗马数字转整数
 */

// @lc code=start
use std::collections::HashMap;
impl Solution {
    fn roman_to_int(s: String) -> i32 {
        let mut roman_chars_nums = HashMap::new();
        let s: Vec<char> = s.chars().collect();
        roman_chars_nums.insert('M', 1000);
        roman_chars_nums.insert('D', 500);
        roman_chars_nums.insert('C', 100);
        roman_chars_nums.insert('L', 50);
        roman_chars_nums.insert('X', 10);
        roman_chars_nums.insert('V', 5);
        roman_chars_nums.insert('I', 1);
        let mut res = 0;
        if let Some(value) = roman_chars_nums.get(&(s[0])) {
            res = *value;
        }
        for i in 1..s.len() {
            let mut v1 = 0;
            let mut v2 = 0;
            if let Some(value1) = roman_chars_nums.get(&s[i]) {
                v1 = *value1;
            }
            if let Some(value2) = roman_chars_nums.get(&s[i - 1]) {
                v2 = *value2;
            }
            if v1 > v2 {
                res += v1 - 2 * v2;
            } else {
                res += v1;
            }
        }
        res
    }
}
// @lc code=end
