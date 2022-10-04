/*
 * @lc app=leetcode.cn id=91 lang=cpp
 *
 * [91] 解码方法
 */
#include <iostream>
#include <vector>
#include <string>
using namespace std;
// @lc code=start
class Solution {
public:
    int numDecodings(string s) {
        if (s[0] == '0') {
            return 0;
        }
        auto len = s.size();
        if (len == 1) {
            return s == "0" ? 0 : 1;
        }
        if (len == 2) {
            int temp = stoi(s);
            if (temp % 10 == 0 && temp >= 30) {
                return 0;
            } else if (temp > 26 || temp == 10 || temp == 20) {
                return 1;
            } else {
                return 2;
            }
        }
        vector<int> dp(len + 1, 0);
        dp[1] = numDecodings(s.substr(len - 1));
        dp[2] = numDecodings(s.substr(len - 2));
        for (auto i = 3; i <= len; ++i) {
            string tempStr = s.substr(len - i, 2);
            int tempNum = numDecodings(tempStr);
            if (tempNum == 0) {
                dp[i] = 0;
            } else if (tempNum == 1) {
                if (tempStr == "10" || tempStr == "20") {
                    dp[i] = dp[i - 2];
                } else {
                    dp[i] = dp[i - 1];
                }
            } else {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
        }
        return dp[len];
    }
};
// @lc code=end

