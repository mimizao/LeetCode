use std::{collections::HashMap};

fn main() {
    println!("Hello, world!");
}

pub fn letter_combinations(digits: String) -> Vec<String> {
    let mut res = Vec::new();
    if digits.len() == 0{
        return res;
    }
    let digits :Vec<char> = digits.chars().collect();
    let mut map = HashMap::with_capacity(8); 
    map.insert('2',String::from("abc"));
    map.insert('3',String::from("def"));
    map.insert('4',String::from("ghi"));
    map.insert('5',String::from("jkl"));
    map.insert('6',String::from("mno"));
    map.insert('7',String::from("pqrs"));
    map.insert('8',String::from("tuv"));
    map.insert('9',String::from("wxyz"));
    res = get_new_res(res, map, digits, 0, String::from(""));
    res
}

pub fn get_new_res(mut res: Vec<String>,map: HashMap<char,String>,digits: Vec<char>,index:usize,suffix:String) -> Vec<String>{
    if index == digits.len(){
        res.push(suffix);
        return res;
    }else{
        let mut str = String::new();
        if let Some(value) = map.get(&(digits[index])){
            str = value.to_string();
        }
        let str:Vec<char> = str.chars().collect();
        for i in 0..str.len(){
            let new_map = map.clone();
            res = get_new_res(res, new_map, digits,index+1,suffix)
        }
    }
    res
}