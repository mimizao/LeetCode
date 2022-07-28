fn main() {
    println!("Hello, world!");
}

fn three_sum_closest(nums: Vec<i32>, target: i32) -> i32 {
    let mut nums = nums;
    nums.sort();
    let mut res = nums[0] + nums[1] + nums[2];
    let mut difference = i32::MAX;
    for mut first in 0..nums.len() - 2 {
        if first != 0 && nums[first] == nums[first - 1] {
            first += 1;
            continue;
        }
        let mut second = first + 1;
        let mut third = nums.len() - 1;
        while second < third {
            let new_difference = i32::abs(nums[first] + nums[second] + nums[third] - target);
            if new_difference == 0 {
                return nums[first] + nums[second] + nums[third];
            }
            if new_difference < difference {
                difference = new_difference;
                res = nums[first] + nums[second] + nums[third];
            }
            if target > nums[first] + nums[second] + nums[third] {
                second += 1;
                while second < third && nums[second] == nums[second + 1] {
                    second += 1;
                }
            }else{
                third -= 1;
                while second < third && nums[third] == nums[third-1]{
                    third -= 1;
                }
            }
        }
    }
    res
}
