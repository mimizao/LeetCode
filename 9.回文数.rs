/*
 * @lc app=leetcode.cn id=9 lang=rust
 *
 * [9] 回文数
 */

// @lc code=start
impl Solution {
    pub fn is_palindrome(x: i32) -> bool {
        if x < 0 {
            return false;
        }
        let s = x.to_string();
        let c: Vec<char> = s.chars().collect();
        let mut left = 0;
        let mut right = c.len() - 1;
        while left < right {
            if c[left] == c[right] {
                left += 1;
                right -= 1;
            } else {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end
impl Solution {
    pub fn is_palindrome(x: i32) -> bool {
        if (x < 0) || (x % 10 == 0 && x != 0) {
            return false;
        }
        let mut x = x;
        let mut reverted_number = 0;
        while x > reverted_number {
            reverted_number = reverted_number * 10 + x % 10;
            x /= 10;
        }
        x == reverted_number || x == reverted_number / 10
    }
}
