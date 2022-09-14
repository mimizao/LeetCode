fn main() {
    println!("Hello, world!");
}

pub fn set_zeroes(matrix: &mut Vec<Vec<i32>>) {
    let m = matrix.len();
    let n = matrix[0].len();
    let mut row_flag = vec![false; m];
    let mut col_flag = vec![false; n];
    for i in 0..m {
        for j in 0..n {
            if matrix[i][j] == 0 {
                row_flag[i] = true;
                col_flag[j] = true;
            }
        }
    }
    for i in 0..m {
        for j in 0..n {
            if row_flag[i] || col_flag[j] {
                matrix[i][j] = 0;
            }
        }
    }
}
