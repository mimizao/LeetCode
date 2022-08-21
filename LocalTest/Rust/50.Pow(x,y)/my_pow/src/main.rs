fn main() {
    let x = 0.00001;
    let n = 2147483647;
    let res = my_pow(x, n);
    println!("{}", res);
}


pub fn my_pow(x: f64, n: i32) -> f64 {
    if n >= 0 {
        return my_quick_mul(x, n);
    }
    return 1.00000 / my_quick_mul(x, -n);
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

pub fn my_quick_mul(x: f64, n: i32) -> f64 {
    if n == 0 {
        return 1.0000;
    }
    if n == 1 {
        return x;
    }
    let mut count = 1;
    let mut res = x;
    while count <= n / 2 {
        res *= res;
        count *= 2;
    }
    res *= my_quick_mul(x, n - count);
    return res;
}
