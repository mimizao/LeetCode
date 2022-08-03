fn main() {
    println!("Hello, world!");
}

pub fn search_range(nums: Vec<i32>, target: i32) -> Vec<i32> {
    let mut left: i32 = 0;
    let mut right: i32 = nums.len() as i32 - 1;
    while left <= right {
        let mid = (left + right) / 2;
        if nums[mid as usize] == target {
            let mut begin = mid;
            let mut end = mid;
            while begin > 0 && nums[begin as usize - 1] == target {
                begin -= 1;
            }
            while end < nums.len() as i32 - 1 && nums[end as usize + 1] == target {
                end += 1;
            }
            return vec![begin, end];
        } else if nums[mid as usize] < target {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return vec![-1, -1];
}
