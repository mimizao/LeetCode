/*
 * @lc app=leetcode.cn id=72 lang=rust
 *
 * [72] 编辑距离
 */

// @lc code=start
impl Solution {
    pub fn min_distance(word1: String, word2: String) -> i32 {
        let word1: Vec<char> = word1.chars().collect();
        let word2: Vec<char> = word2.chars().collect();
        let len1 = word1.len();
        let len2 = word2.len();
        if len1 == 0 || len2 == 0 {
            return max(len1 as i32, len2 as i32);
        }
        let mut dp = vec![vec![0; len2 + 1]; len1 + 1];
        for i in 0..=len1 {
            dp[i][0] = i as i32;
        }
        for i in 0..=len2 {
            dp[0][i] = i as i32;
        }
        for i in 1..=len1 {
            for j in 1..=len2 {
                let left = dp[i - 1][j] + 1;
                let down = dp[i][j - 1] + 1;
                let mut left_down = dp[i - 1][j - 1];
                if word1[i - 1] != word2[j - 1] {
                    left_down += 1;
                }
                dp[i][j] = min(left, min(down, left_down));
            }
        }
        dp[len1][len2]
    }
}
// @lc code=end

