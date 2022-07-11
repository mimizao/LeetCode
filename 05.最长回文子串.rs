/*
 * @lc app=leetcode.cn id=5 lang=rust
 *
 * [5] 最长回文子串
 */

// @lc code=start
impl Solution {
    pub fn longest_palindrome(s: String) -> String {
        let len = s.len();
        if len < 2 {
            return s;
        }
        let chars: Vec<_> = s.chars().collect();
        let mut max_len = 1;
        let mut begin = 0;
        let mut dp: Vec<Vec<bool>> = vec![vec![false; len]; len];
        for temp_len in 2..=len {
            for left in 0..len {
                let right = left + temp_len - 1;
                if right >= len {
                    break;
                }
                if chars[left] != chars[right] {
                    dp[left][right] = false;
                } else {
                    if right - left < 3 {
                        dp[left][right] = true;
                    } else {
                        dp[left][right] = dp[left + 1][right - 1];
                    }
                }
                if dp[left][right] && temp_len > max_len {
                    max_len = temp_len;
                    begin = left;
                }
            }
        }
        (&s[begin..begin + max_len]).to_string()
    }
}
// @lc code=end
