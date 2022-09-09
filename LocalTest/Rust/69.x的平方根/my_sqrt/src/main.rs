fn main() {
    let x = 2;
    let res = my_sqrt(x);
    println!("{}", res);
}

pub fn my_sqrt(x: i32) -> i32 {
    if x == 0 || x == 1 {
        return x;
    }
    let x = x as u64;
    let mut left = 0;
    let mut right = x;
    let mut res = 0;
    while left <= right {
        let mid = (left + right) / 2;
        if mid * mid <= x {
            res = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    res as i32
}
