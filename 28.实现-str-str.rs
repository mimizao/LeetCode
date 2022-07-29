/*
 * @lc app=leetcode.cn id=28 lang=rust
 *
 * [28] 实现 strStr()
 */

// @lc code=start
impl Solution {
    pub fn str_str(haystack: String, needle: String) -> i32 {
        let haystack: Vec<char> = haystack.chars().collect();
        let needle: Vec<char> = needle.chars().collect();
        let haystack_len = haystack.len();
        let needle_len = needle.len();
        if haystack_len < needle_len {
            return -1;
        }
        for i in 0..=haystack_len - needle_len {
            if haystack[i] == needle[0] && &haystack[i..(i + needle_len)] == &needle {
                return i as i32;
            }
        }
        -1
    }
}
// @lc code=end

