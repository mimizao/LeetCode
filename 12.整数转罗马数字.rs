/*
 * @lc app=leetcode.cn id=12 lang=rust
 *
 * [12] 整数转罗马数字
 */

// @lc code=start
impl Solution {
    pub fn int_to_roman(num: i32) -> String {
        let mut res = String::new();
        let roman_strs = vec![
            "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I",
        ];
        let roman_nums = vec![1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];
        let mut new_num = num;
        let mut i = 0;

        while i < 13 {
            if new_num >= roman_nums[i] {
                res+=roman_strs[i]
                new_num -= roman_nums[i];
            }else{
                i+=1;
            }
        }
        res
    }
}
// @lc code=end
