/*
 * @lc app=leetcode.cn id=62 lang=rust
 *
 * [62] 不同路径
 */

// @lc code=start
impl Solution {
    pub fn unique_paths(m: i32, n: i32) -> i32 {
        if m == 1 || n == 1 {
            return 1;
        }
        let (m, n) = (m as usize, n as usize);
        let mut dp = vec![vec![0 as i32; n]; m];
        for i in 0..n {
            dp[0][i] = 1;
        }
        for i in 0..m {
            dp[i][0] = 1;
        }
        for i in 1..m {
            for j in 1..n {
                dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
            }
        }
        dp[m - 1][n - 1]
    }
    
    pub fn unique_path1(m: i32, n: i32) -> i32 {
        if m == 1 || n == 1 {
            return 1;
        }
        let (m, n) = (m as usize, n as usize);
        let mut pre = vec![1; n];
        let mut cur = vec![1; n];
        for _ in 1..m {
            for j in 1..n {
                cur[j] = pre[j] + cur[j - 1];
            }
            pre = cur.clone();
        }
        pre[n - 1]
    }
    
    pub fn unique_paths2(m: i32, n: i32) -> i32 {
        if m == 1 || n == 1 {
            return 1;
        }
        let (m, n) = (m as usize, n as usize);
        let mut cur = vec![1; n];
        for _ in 1..m {
            for j in 1..n {
                cur[j] += cur[j - 1];
            }
        }
        cur[n - 1]
    }
}
// @lc code=end
