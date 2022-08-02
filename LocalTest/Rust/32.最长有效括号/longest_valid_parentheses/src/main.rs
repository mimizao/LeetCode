fn main() {
    println!("Hello, world!");
}

pub fn longest_valid_parentheses(s: String) -> i32 {
    let mut res = 0;
    let mut dp:Vec<usize> = vec![0;s.len()];
    let s: Vec<char> = s.chars().collect();
    for i in 1..s.len() {
        if s[i] == ')' {
            if s[i - 1] == '(' {
                if i >= 2 {
                    dp[i] = dp[i - 2] + 2;
                } else {
                    dp[i] = 2;
                }
            } else if i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(' {
                if i - dp[i - 1] >= 2 {
                    dp[i] = dp[i - 1] + dp[i - dp[i - 1] - 2] + 2;
                } else {
                    dp[i] = dp[i - 1] + 2;
                }
            }
            if dp[i] > res {
                res = dp[i];
            }
        }
    }
    res as i32
}
