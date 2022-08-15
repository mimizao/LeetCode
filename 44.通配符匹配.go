/*
 * @lc app=leetcode.cn id=44 lang=golang
 *
 * [44] 通配符匹配
 */
package main

// @lc code=start
func isMatch(s string, p string) bool {
	lenS, lenP := len(s), len(p)
	dp := make([][]bool, lenS+1)
	for i := 0; i <= lenS; i++ {
		dp[i] = make([]bool, lenP+1)
	}
	dp[0][0] = true
	for i := 1; i <= lenP; i++ {
		if p[i-1] == '*' {
			dp[0][i] = true
		} else {
			break
		}
	}
	for i := 1; i <= lenS; i++ {
		for j := 1; j <= lenP; j++ {
			if p[j-1] == '*' {
				dp[i][j] = dp[i][j-1] || dp[i-1][j]
			} else if p[j-1] == '?' || s[i-1] == p[j-1] {
				dp[i][j] = dp[i-1][j-1]
			}
		}
	}
	return dp[lenS][lenP]
}

// @lc code=end
