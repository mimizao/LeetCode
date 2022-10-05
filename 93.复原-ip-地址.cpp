/*
 * @lc app=leetcode.cn id=93 lang=cpp
 *
 * [93] 复原 IP 地址
 */
#include <iostream>
#include <vector>

using namespace std;
// @lc code=start
class Solution {
public:
    vector<string> restoreIpAddresses(string s) {
        vector<string> res;
        auto len = s.length();
        if (len < 4 || len > 12) {
            return res;
        }
        vector<string> path;
        dfs(s, len, 0, 4, path, res);
        return res;
    }

    void dfs(string s, unsigned long long len, int begin, int residue, vector<string> &path, vector<string> &res) {
        if (begin == len) {
            if (residue == 0) {
                string tempStr;
                for (int i = 0; i < path.size() - 1; i++) {
                    tempStr += path[i] + ".";
                }
                tempStr += path[path.size() - 1];
                res.push_back(tempStr);
                return;
            }
        }
        for (int i = begin; i < begin + 3; i++) {
            if (i >= len) {
                break;
            }
            if (residue * 3 < len - i) {
                continue;
            }
            if (judgeIpSegment(s, begin, i)) {
                string currentIpSegment = s.substr(begin, i - begin + 1);
                path.push_back(currentIpSegment);
                dfs(s, len, i + 1, residue - 1, path, res);
                path.pop_back();
            }
        }
    }

    bool judgeIpSegment(string s, int left, int right) {
        int len = right - left + 1;
        if (len > 1 && s[left] == '0') {
            return false;
        }
        int res = 0;
        while (left <= right) {
            res = res * 10 + s[left] - '0';
            left++;
        }
        return res >= 0 && res <= 255;
    }
};
// @lc code=end

