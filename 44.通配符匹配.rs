/*
 * @lc app=leetcode.cn id=44 lang=rust
 *
 * [44] 通配符匹配
 */

// @lc code=start
impl Solution {
    pub fn is_match(s: String, p: String) -> bool {
        let s = s.chars().collect::<Vec<char>>();
        let p = p.chars().collect::<Vec<char>>();
        let (len_s, len_p) = (s.len(), p.len());
        let mut dp = vec![vec![false; len_p + 1]; len_s + 1];
        dp[0][0] = true;
        for i in 1..=len_p {
            if p[i - 1] == '*' {
                dp[0][i] = true;
            } else {
                break;
            }
        }

        for i in 1..=len_s {
            for j in 1..=len_p {
                if p[j - 1] == '*' {
                    dp[i][j] = dp[i][j - 1] || dp[i - 1][j];
                } else if p[j - 1] == '?' || s[i - 1] == p[j - 1] {
                    dp[i][j] = dp[i - 1][j - 1];
                }
            }
        }
        dp[len_s][len_p]
    }
}
// @lc code=end

