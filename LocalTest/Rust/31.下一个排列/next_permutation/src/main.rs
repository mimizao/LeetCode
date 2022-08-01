fn main() {
    let mut nums = vec![1, 2];
    next_permutation(&mut nums);
    println!("{:?}", nums);
}

pub fn next_permutation(nums: &mut Vec<i32>) {
    let len = nums.len() as i32;
    let mut left = len - 2;
    let mut right = len - 1;
    while left >= 0 && nums[left as usize] >= nums[left as usize + 1] {
        left -= 1;
    }
    if left >= 0 {
        while right >= 0 && nums[left as usize] >= nums[right as usize] {
            right -= 1;
        }
        (nums[left as usize],nums[right as usize]) = (nums[right as usize],nums[left as usize]);
    }
    reverted_nums(nums, left as usize + 1)
}

pub fn reverted_nums(nums: &mut Vec<i32>, mut left: usize) {
    let mut right = nums.len() - 1;
    while left < right {
        (nums[left as usize],nums[right as usize]) = (nums[right as usize],nums[left as usize]);
        left += 1;
        right -= 1;
    }
}
