fn main() {
    let res = generate_parenthesis(3);
    println!("{:?}", res);
}

fn generate_parenthesis(n: i32) -> Vec<String> {
    let mut res = vec![];

    return res;
}

fn generate(mut res: &Vec<String>, str: String, left_count: i32, right_count: i32, n: i32) {
    if left_count > n || right_count > n || right_count > left_count {
        return;
    }
    if left_count == n && right_count == n {
        (res).push(str.clone())
    }
    generate(res, &str + "(", left_count + 1, right_count, n);
    generate(res, str+")", left_count, right_count, n);
    return;
}
