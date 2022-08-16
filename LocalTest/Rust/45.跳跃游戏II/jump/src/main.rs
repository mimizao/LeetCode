fn main() {
    println!("Hello, world!");
}

pub fn jump(nums: Vec<i32>) -> i32 {
    let len = nums.len();
    let mut count = 0;
    let mut begin = 0;
    while begin <= len - 1 {
        if begin == len - 1 {
            break;
        } else if begin + nums[begin] as usize >= len - 1 {
            count += 1;
            break;
        } else {
            let mut temp = 0;
            let mut new_begin = begin;
            for i in 1..=nums[begin] as usize {
                if temp <= nums[begin + i] + i as i32 {
                    temp = nums[begin + i] + i as i32;
                    new_begin = begin + i;
                }
            }
            count += 1;
            begin = new_begin;
        }
    }
    count
}
