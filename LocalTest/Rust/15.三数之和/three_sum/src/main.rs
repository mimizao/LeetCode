use std::vec;

fn main() {
    let nums = vec![-1,0,1,2,-1,-4];
    let res = three_sum(nums);
    println!("{:?}", res);
}

fn three_sum(nums: Vec<i32>) -> Vec<Vec<i32>> {
    let len = nums.len();
    if len < 3 {
        return vec![];
    }
    let mut res= vec![];
    let mut new_nums = nums;
    new_nums.sort();
    for first in 0..len - 2 {
        if first != 0 && new_nums[first] == new_nums[first - 1] {
            continue;
        }
        let mut third = len - 1;
        let target = 0 - new_nums[first];
        for second in first+1..len - 1 {
            if second != first + 1 && new_nums[second] == new_nums[second - 1] {
                continue;
            }
            while second < third && new_nums[second] + new_nums[third] > target {
                third -= 1;
            }
            if second == third {
                break;
            }
            if new_nums[second] + new_nums[third] == target {
                res.push(vec![new_nums[first], new_nums[second], new_nums[third]]);
            }
        }
    }
    res
}
