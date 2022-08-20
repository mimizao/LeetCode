/*
 * @lc app=leetcode.cn id=49 lang=typescript
 *
 * [49] 字母异位词分组
 */
let strs = ["eat", "tea", "tan", "ate", "nat", "bat"];
let res = groupAnagrams(strs);
console.log(res);
// @lc code=start
function groupAnagrams(strs: string[]): string[][] {
    let len = strs.length;
    let myMap: Map<string, string[]> = new Map();
    for (let i = 0; i < len; i++) {
        let temp = Array.from(strs[i]).sort().join();
        if (!myMap.has(temp)) {
            myMap.set(temp, []);
        }
        myMap.get(temp)?.push(strs[i]);
    }
    return [...myMap.values()];
};
// @lc code=end

