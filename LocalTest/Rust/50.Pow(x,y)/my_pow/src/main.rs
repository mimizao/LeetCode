fn main() {
    let x = 2.00000;
    let n = -10;
    let res = my_pow(x, n);
    println!("{}", res);
}


pub fn my_pow(x: f64, n: i32) -> f64 {
    if n >= 0 {
        return quick_mul(x, n);
    }
    return 1.00000 / quick_mul(x, -n);
}

pub fn quick_mul(x: f64, n: i32) -> f64 {
    if n == 0 {
        return 1.00000;
    }
    let y = quick_mul(x, n / 2);
    return if n % 2 == 0 {
        y * y
    } else {
        y * y * x
    };
}
