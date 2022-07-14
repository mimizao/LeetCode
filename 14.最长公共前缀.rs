/*
 * @lc app=leetcode.cn id=14 lang=rust
 *
 * [14] 最长公共前缀
 */

// @lc code=start
impl Solution {
    pub fn longest_common_prefix(strs: Vec<String>) -> String {
        let len = strs.len();
        if len <= 1 {
            return strs[0].clone();
        }
        let mut res = strs[0].clone();
        let mut res_len = res.len();
        for i in 1..len {
            res = get_two_strs_common_prefix(&res, &strs[i], res_len);
            if res.len() == 0 {
                return String::from("");
            }
            res_len = res.len();
        }
        res
    }
}

pub fn get_two_strs_common_prefix(str1: &String, str2: &String, res_len: usize) -> String {
    let mut new_res_len = 0;
    let s1: Vec<char> = str1.chars().collect();
    let s2: Vec<char> = str2.chars().collect();
    for i in 0..res_len {
        if i >= s1.len() || i >= s2.len() {
            break;
        }
        if s1[i] == s2[i] {
            new_res_len += 1;
        } else {
            break;
        }
    }
    let new_res = &str1[0..new_res_len];
    return new_res.to_string();
}
// @lc code=end
