fn main() {
    let nums = vec![3, 3, 0, 3];
    let res = permute_unique(nums);
    println!("{:?}", res);
}

pub fn permute_unique(nums: Vec<i32>) -> Vec<Vec<i32>> {
    let mut res = vec![];
    let len = nums.len();
    if len == 0 {
        return res;
    }
    let mut path = vec![];
    let mut used = vec![false; len];
    let mut nums = nums;
    nums.sort_unstable();
    dfs(&nums, &mut path, &mut used, &mut res);
    res
}

pub fn dfs(nums: &Vec<i32>, path: &mut Vec<i32>, used: &mut Vec<bool>, res: &mut Vec<Vec<i32>>) {
    if path.len() == nums.len() {
        res.push(path.clone());
        return;
    }
    for i in 0..nums.len() {
        if used[i] {
            continue;
        }
        if i > 0 && nums[i] == nums[i - 1] && !used[i - 1] {
            continue;
        }
        path.push(nums[i]);
        used[i] = true;
        dfs(&nums, path, used, res);
        used[i] = false;
        path.pop();
    }
}

