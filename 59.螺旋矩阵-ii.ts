/*
 * @lc app=leetcode.cn id=59 lang=typescript
 *
 * [59] 螺旋矩阵 II
 */

// @lc code=start
function generateMatrix(n: number): number[][] {
    let res = new Array(n);
    for (let i = 0; i < n; i++) {
        res[i] = new Array(n);
    }
    let up = 0;
    let down = n - 1;
    let left = 0;
    let right = n - 1;
    let num = 1;
    let maxNum = n * n;
    while (num <= maxNum) {
        for (let i = left; i <= right && num <= maxNum; i++) {
            res[up][i] = num;
            num++;
        }
        up++;
        for (let i = up; i <= down && num <= maxNum; i++) {
            res[i][right] = num;
            num++;
        }
        right--;
        for (let i = right; i >= left && num <= maxNum; i--) {
            res[down][i] = num;
            num++;
        }
        down--;
        for (let i = down; i >= up && num <= maxNum; i--) {
            res[i][left] = num;
            num++;
        }
        left++;
    }
    return res
}
// @lc code=end

