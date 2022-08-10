fn main() {
    let nums = vec![3,4,-1,1,2,8,0,9];
    let res = first_missing_positive(nums);
    println!("{}", res);
}

pub fn first_missing_positive(nums: Vec<i32>) -> i32 {
    let mut nums = nums;
    let len = nums.len();
    if len == 0 {
        return 0;
    }
    for i in 0..len {
        if nums[i] <= 0 {
            nums[i] = len as i32 + 1;
        }
    }
    for i in 0..len {
        let num = i32::abs(nums[i]);
        if num as usize <= len {
            nums[num as usize - 1] = -i32::abs(nums[num as usize - 1])
        }
    }
    for i in 0..len {
        if nums[i] >= 0 {
            return i as i32 + 1;
        }
    }
    len as i32 + 1
}
