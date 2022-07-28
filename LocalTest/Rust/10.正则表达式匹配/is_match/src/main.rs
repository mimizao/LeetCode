fn main() {
    println!("Hello, world!");
    let s = String::from("a");
    let p = String::from(".*");
    let res = is_match(s, p);
    println!("{}", res);
}

pub fn is_match(s: String, p: String) -> bool {
    let m = s.len();
    let n = p.len();
    let s: Vec<char> = s.chars().collect();
    let p: Vec<char> = p.chars().collect();
    let mut f: Vec<Vec<bool>> = vec![vec![false; m + 1]; m + 1];
    f[0][0] = true;
    for i in 0..=m {
        for j in 1..=n {
            if p[j - 1] == '*' {
                f[i][j] = f[i][j - 2];
                if matches(&s, &p, i,j - 1) {
                    f[i][j] = f[i][j] || f[i - 1][j];
                }
            } else {
                if matches(&s, &p, i, j) {
                    f[i][j] = f[i - 1][j - 1];
                }
            }
        }
    }
    return f[m][n];
}

pub fn matches(s: &Vec<char>, p: &Vec<char>, i: usize, j: usize) -> bool {
    if i == 0 {
        return false;
    }
    if p[j - 1] == '.' {
        return false;
    }
    s[i - 1] == p[j - 1]
}
