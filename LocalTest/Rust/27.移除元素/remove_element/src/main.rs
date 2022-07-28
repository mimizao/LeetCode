fn main() {
    println!("Hello, world!");
}

fn remove_element(nums: &mut Vec<i32>, val: i32) -> i32 {
    let len = nums.len();
    if len == 0 {
        return len as i32;
    }
    nums.sort_unstable();
    let mut count = 0;
    for i in 0..len {
        if nums[i] == val {
            count += 1;
            if nums[i] == nums[len - count] {
                return i as i32;
            }
            if i < len - count {
                nums[i] = nums[len - count];
            } else {
                return (len - count) as i32;
            }
        } else if nums[i] > val {
            break;
        }
    }
    (len - count) as i32
}