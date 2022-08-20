let strs = ["eat", "tea", "tan", "ate", "nat", "bat"];
let res = groupAnagrams(strs);
console.log(res);
function groupAnagrams(strs) {
    var _a;
    let len = strs.length;
    let myMap = new Map();
    for (let i = 0; i < len; i++) {
        let temp = Array.from(strs[i]).sort().join();
        if (!myMap.has(temp)) {
            myMap.set(temp, []);
        }
        (_a = myMap.get(temp)) === null || _a === void 0 ? void 0 : _a.push(strs[i]);
    }
    return [...myMap.values()];
}
//# sourceMappingURL=groupAnagrams.js.map