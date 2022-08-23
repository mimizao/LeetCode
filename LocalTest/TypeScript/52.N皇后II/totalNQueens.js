function totalNQueens(n) {
    var res = 0;
    function dfs(n, row, col, ld, rd) {
        if (row >= n) {
            res++;
        }
        var bits = ~(col | ld | rd) & ((1 << n) - 1);
        while (bits > 0) {
            var pick = bits & -bits;
            dfs(n, row + 1, col | pick, (ld | pick) << 1, (rd | pick) >> 1);
            bits &= bits - 1;
        }
    }
    dfs(n, 0, 0, 0, 0);
    return res;
}
var res = totalNQueens(4);
console.log(res);
