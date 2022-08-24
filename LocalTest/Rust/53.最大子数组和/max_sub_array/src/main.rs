use std::cmp::max;

fn main() {
    let nums = vec![-2, 1, -3, 4, -1, 2, 1, -5, 4];
    let res = max_sub_array(nums);
    println!("{}", res);
}

pub fn max_sub_array(nums: Vec<i32>) -> i32 {
    let mut pre = 0;
    let mut res = nums[0];
    for v in nums {
        pre = max(pre + v, v);
        res = max(res, pre);
    }
    res
}
