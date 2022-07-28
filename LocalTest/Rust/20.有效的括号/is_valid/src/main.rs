fn main() {
    let s = String::from("([)]");
    let res = is_valid(s);
    println!("{}", res);
}

fn is_valid(s: String) -> bool {
    if s.len() % 2 == 1 {
        return false;
    }
    let mut stack: Vec<char> = vec![];
    for c in s.chars() {
        match c {
            '(' | '[' | '{' => stack.push(c),
            ')' => {
                if stack.len() == 0 || stack.pop().unwrap() != '(' {
                    return false;
                }
            }
            ']' => {
                if stack.len() == 0 || stack.pop().unwrap() != '[' {
                    return false;
                }
            }
            '}' => {
                if stack.len() == 0 || stack.pop().unwrap() != '{' {
                    return false;
                }
            }
            _ => (),
        }
    }
    stack.len() == 0
}
