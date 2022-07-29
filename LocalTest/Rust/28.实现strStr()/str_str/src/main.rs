fn main() {
    let haystack = String::from("aaa");
    let needle = String::from("aaaa");
    let res = str_str(haystack, needle);
    println!("{}", res);
}

pub fn str_str(haystack: String, needle: String) -> i32 {
    let haystack: Vec<char> = haystack.chars().collect();
    let needle: Vec<char> = needle.chars().collect();
    let haystack_len = haystack.len();
    let needle_len = needle.len();
    if haystack_len < needle_len {
        return -1;
    }
    for i in 0..=haystack_len - needle_len {
        if haystack[i] == needle[0] && &haystack[i..(i + needle_len)] == &needle {
            return i as i32;
        }
    }
    -1
}
