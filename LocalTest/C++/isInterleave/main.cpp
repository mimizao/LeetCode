#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    static bool isInterleave(const string &s1, const string &s2, const string &s3) {
        auto len1 = s1.length();
        auto len2 = s2.length();
        auto len3 = s3.length();
        if (len1 + len2 != len3) {
            return false;
        }
        if (len1 == 0 || len2 == 0) {
            return s1 == s3 || s2 == s3;
        }
        vector<vector<bool>> dp(len1 + 1, vector<bool>(len2 + 1, false));
        dp[0][0] = true;
        for (int i = 1; i < len1; i++) {
            dp[i][0] = s1.substr(0, i) == s3.substr(0, i);
        }
        for (int i = 1; i < len2; i++) {
            dp[0][i] = s2.substr(0, i) == s3.substr(0, i);
        }
        for (int i = 1; i <= len1; i++) {
            for (int j = 1; j <= len2; j++) {
                dp[i][j] = (dp[i - 1][j] && s1.substr(i - 1, 1) == s3.substr(i - 1 + j, 1)) ||
                           (dp[i][j - 1] && s2.substr(j - 1, 1) == s3.substr(i + j - 1, 1)) ||
                           (dp[i - 1][j - 1] &&
                            (s1.substr(i - 1, 1) + s2.substr(j - 1, 1) == s3.substr(i - 1 + j - 1, 2) ||
                             s2.substr(j - 1, 1) + s1.substr(i - 1, 1) == s3.substr(i - 1 + j - 1, 2)));
            }
        }
        return dp[len1][len2];
    }
};

int main() {
    auto res = Solution::isInterleave("aabcc", "dbbca", "aadbbcbcac");
    std::cout << res << std::endl;
    return 0;
}
