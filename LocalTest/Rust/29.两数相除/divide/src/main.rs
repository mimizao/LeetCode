fn main() {
    let dividend = 7;
    let divisor =-3;
    let res = divide(dividend, divisor);
    println!("res: {}", res);
}

pub fn divide(dividend: i32, divisor: i32) -> i32 {
    if dividend == 0 {
        return 0;
    }
    if divisor == 1 {
        return dividend;
    }
    if dividend == -1 {
        if dividend > i32::MIN {
            return -dividend;
        }
    }
    let mut flag = 1;
    if (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0) {
        flag = -1;
    }
    let mut dividend = dividend as i64;
    let mut divisor = divisor as i64;
    if dividend < 0 {
        dividend = -dividend;
    }
    if divisor < 0 {
        divisor = -divisor;
    }
    let res = div(dividend, divisor);
    if flag > 0 {
        if res > 2147483647 {
            return i32::MAX;
        }
        return res as i32;
    }
    return -res as i32;
}

pub fn div(dividend: i64, divisor: i64) -> i64 {
    if dividend < divisor {
        return 0;
    }
    let mut count = 1;
    let mut temp_divisor = divisor;
    while temp_divisor + temp_divisor <= dividend {
        count += count;
        temp_divisor += temp_divisor;
    }
    return count + div(dividend - temp_divisor, divisor);
}
