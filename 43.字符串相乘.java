/*
 * @lc app=leetcode.cn id=43 lang=java
 *
 * [43] 字符串相乘
 */

// @lc code=start
class Solution {
    public String multiply(String num1, String num2) {
        if (num1.equals("0") || num2.equals("0")) {
            return "0";
        }
        StringBuilder res = new StringBuilder();
        int len1 = num1.length();
        int len2 = num2.length();
        int[] resArr = new int[len1 + len2];

        for (int i = len1 - 1; i >= 0; i--) {
            int x = num1.charAt(i) - '0';
            for (int j = len2 - 1; j >= 0; j--) {
                int y = num2.charAt(j) - '0';
                resArr[i + j + 1] += x * y;
            }
        }

        for (int i = len1 + len2 - 1; i > 0; i--) {
            resArr[i - 1] += resArr[i] / 10;
            resArr[i] %= 10;
        }

        int begin = resArr[0] == 0 ? 1 : 0;
        for (int i = begin; i < len1 + len2; i++) {
            res.append(resArr[i]);
        }
        return res.toString();
    }
}
// @lc code=end

