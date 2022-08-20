#include <iostream>
#include <vector>
#include<algorithm>
#include <unordered_map>

using namespace std;

class Solution {
public:
    vector<vector<string>> groupAnagrams1(vector<string> &strs) {
        vector<vector<string>> res;
        int len = strs.size();
        if (len == 1) {
            res.push_back(strs);
            return res;
        }

        vector<bool> used = vector<bool>(len, false);
        vector<string> tempRes;
        string tempI;
        string tempJ;
        for (int i = 0; i < len; i++) {
            if (used[i]) {
                continue;
            }
            tempRes.push_back(strs[i]);
            used[i] = true;
            tempI = strs[i];
            int lenI = tempI.length();
            sort(tempI.begin(), tempI.end());
            for (int j = i + 1; j < len; j++) {
                if (used[j] || lenI != strs[j].length()) {
                    continue;
                }
                tempJ = strs[j];
                sort(tempJ.begin(), tempJ.end());
                if (tempI == tempJ) {
                    tempRes.push_back(strs[j]);
                    used[j] = true;
                }
            }
            res.push_back(tempRes);
            tempRes.clear();
        }
        return res;
    }

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


int main() {
    Solution solution;
    vector<string> strs = {"eat", "tea", "tan", "ate", "nat", "bat"};
    //auto res = solution.groupAnagrams1(strs);
    auto res = solution.groupAnagrams(strs);
    return 0;
}
