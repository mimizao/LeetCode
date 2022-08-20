let strs = ["eat", "tea", "tan", "ate", "nat", "bat"];
let res = groupAnagrams(strs);
console.log(res);

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
}