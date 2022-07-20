/*
 * @lc app=leetcode.cn id=20 lang=rust
 *
 * [20] 有效的括号
 */

// @lc code=start
impl Solution {
    pub fn is_valid(s: String) -> bool {
        if s.len() % 2 == 1 {
            return false;
        }
        let mut stack: Vec<char> = vec![];
        for c in s.chars() {
            match c {
                '(' | '[' | '{' => stack.push(c),
                ')' => {
                    if stack.len() == 0 || stack.pop().unwrap() != '(' {
                        return false;
                    }
                }
                ']' => {
                    if stack.len() == 0 || stack.pop().unwrap() != '[' {
                        return false;
                    }
                }
                '}' => {
                    if stack.len() == 0 || stack.pop().unwrap() != '{' {
                        return false;
                    }
                }
                _ => (),
            }
        }
        stack.len() == 0
    }
}
// @lc code=end

