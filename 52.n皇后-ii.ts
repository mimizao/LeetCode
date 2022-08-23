/*
 * @lc app=leetcode.cn id=52 lang=typescript
 *
 * [52] N皇后 II
 */

// @lc code=start
function totalNQueens(n: number): number {
    let res: number = 0;

    function dfs(n: number, row: number, col: number, ld: number, rd: number) {
        if (row >= n) {
            res++;
        }
        let bits = ~(col | ld | rd) & ((1 << n) - 1);
        while (bits > 0) {
            let pick = bits & -bits;
            dfs(n, row + 1, col | pick, (ld | pick) << 1, (rd | pick) >> 1);
            bits &= bits - 1;
        }
    }

    dfs(n, 0, 0, 0, 0);
    return res;
}
// @lc code=end

