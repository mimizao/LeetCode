fn main() {
    let mut nums = vec![1, 1, 2];
    let res = remove_duplicates(&mut nums);
    println!("res: {}", res);
}

fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
    let len = nums.len();
    if len <= 1 {
        return len as i32;
    }
    let mut left = 0;
    let mut right = 1;
    let mut res = len;
    while right < len {
        if nums[left] >= nums[right] {
            if nums[left] == nums[len - 1] {
                return right as i32;
            }
            let mut index = right;
            while right < len - 1 {
                if nums[index] > nums[left] && nums[index] > nums[right] {
                    break;
                } else {
                    index += 1;
                }
            }
            nums[right] = nums[index];
            res -= 1;
        }
        left += 1;
        right += 1;
    }
    res as i32
}
