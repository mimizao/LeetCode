/*
 * @lc app=leetcode.cn id=44 lang=cpp
 *
 * [44] 通配符匹配
 */
#include <vector>;
#include <string>;

using namespace std;
// @lc code=start
class Solution {
public:
    bool isMatch(string s, string p) {
        int lenS = s.size();
        int lenP = p.size();
        vector<vector<int>> dp(lenS + 1, vector<int>(lenP + 1));
        dp[0][0] = true;
        for (int i = 1; i <= lenP; i++) {
            if (p[i - 1] == '*') {
                dp[0][i] = true;
            } else {
                break;
            }
        }

        for (int i = 1; i <= lenS; i++) {
            for (int j = 1; j <= lenP; j++) {
                if (p[j - 1] == '*') {
                    dp[i][j] = dp[i][j - 1] | dp[i - 1][j];
                } else if (p[j - 1] == '?' || s[i - 1] == p[j - 1]) {
                    dp[i][j] = dp[i - 1][j - 1];
                }
            }
        }
        return dp[lenS][lenP];
    }
};
// @lc code=end

