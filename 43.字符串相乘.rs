/*
 * @lc app=leetcode.cn id=43 lang=rust
 *
 * [43] 字符串相乘
 */

// @lc code=start
impl Solution {
    pub fn multiply(num1: String, num2: String) -> String {
        if num1 == String::from("0") || num2 == String::from("0") {
            return String::from("0");
        }
        let len1 = num1.len();
        let len2 = num2.len();
        let mut res_arr = vec![0; len1 + len2];
        let num1 = num1.as_bytes();
        let num2 = num2.as_bytes();
        for i in (0..len1).rev() {
            let x = num1[i] as i32 - 48;
            for j in (0..len2).rev() {
                let y = num2[j] as i32 - 48;
                res_arr[i + j + 1] += x * y;
            }
        }
        for i in (1..len1 + len2).rev() {
            res_arr[i - 1] += res_arr[i] / 10;
            res_arr[i] = res_arr[i] % 10;
        }
        let mut index = 0;
        while index < len1 + len2 - 1 {
            if res_arr[index] == 0 {
                index += 1;
            } else { break; }
        }
        res_arr[index..].into_iter().map(|x| x.to_string()).collect::<String>()
    }
}
// @lc code=end

