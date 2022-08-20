/*
 * @lc app=leetcode.cn id=49 lang=cpp
 *
 * [49] 字母异位词分组
 */
#include <vector>;
#include <unordered_map>;
#include<algorithm>;

using namespace std;
// @lc code=start
class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string> &strs) {
        vector<vector<string>> res;
        int len = strs.size();
        if (len == 1) {
            res.push_back(strs);
            return res;
        }
        unordered_map<string, vector<string>> hashMap;
        string tempStr;
        for (int i = 0; i < len; i++) {
            tempStr = strs[i];
            sort(tempStr.begin(), tempStr.end());
            if (hashMap.find(tempStr) == hashMap.end()) {
                hashMap.insert(pair<string, vector<string>>(tempStr, vector<string>{strs[i]}));
            } else {
                hashMap[tempStr].push_back(strs[i]);
            }
        }
        for (const auto &item: hashMap) {
            res.push_back(item.second);
        }
        return res;
    }
};
// @lc code=end

