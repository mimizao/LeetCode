/*
 * @lc app=leetcode.cn id=30 lang=rust
 *
 * [30] 串联所有单词的子串
 */

// @lc code=start
use std::collections::HashMap;
impl Solution {
    pub fn find_substring(s: String, words: Vec<String>) -> Vec<i32> {
        let mut res: Vec<i32> = Vec::new();
        let s_len = s.len();
        let words_len = words.len();
        let word_len = words[0].len();
        for i in 0..word_len {
            if i + words_len * word_len > s_len {
                break;
            }
            let mut differ = HashMap::new();
            for j in 0..words_len {
                let word = &s[i + j * word_len..i + (j + 1) * word_len];
                let count = differ.entry(word).or_insert(0);
                *count += 1;
                let count = differ.get(word);
                if count == Some(&0) {
                    differ.remove(word);
                }
            }
            for word in &words {
                let word = &word[..];
                let count = differ.entry(word).or_insert(0);
                *count -= 1;
                let count = differ.get(word);
                if count == Some(&0) {
                    differ.remove(word);
                }
            }
            let mut start = i;
            while start < s_len - words_len * word_len + 1 {
                if start != i {
                    let word = &s[start + (words_len - 1) * word_len..start + words_len * word_len];
                    let count = differ.entry(word).or_insert(0);
                    *count += 1;
                    let count = differ.get(word);
                    if count == Some(&0) {
                        differ.remove(word);
                    }
    
                    let word = &s[start - word_len..start];
                    let count = differ.entry(word).or_insert(0);
                    *count -= 1;
                    let count = differ.get(word);
                    if count == Some(&0) {
                        differ.remove(word);
                    }
                }
                if differ.len() == 0 {
                    res.push(start as i32);
                }
                start += word_len;
            }
        }
        res
    }
}
// @lc code=end

