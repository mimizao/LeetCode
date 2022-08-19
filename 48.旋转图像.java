/*
 * @lc app=leetcode.cn id=48 lang=java
 *
 * [48] 旋转图像
 */

// @lc code=start
class Solution {
    public void rotate(int[][] matrix) {
        int len = matrix.length;
        if (len == 1) {
            return;
        }
        int temp1, temp2, temp3, temp4;
        for (int i = 0; i < (len + 1) / 2; i++) {
            for (int j = i; j < len - i - 1; j++) {
                temp1 = matrix[i][j];
                temp2 = matrix[j][len - i - 1];
                temp3 = matrix[len - i - 1][len - j - 1];
                temp4 = matrix[len - j - 1][i];

                matrix[i][j] = temp4;
                matrix[j][len - i - 1] = temp1;
                matrix[len - i - 1][len - j - 1] = temp2;
                matrix[len - j - 1][i] = temp3;
            }
        }
        return;
    }
}
// @lc code=end

