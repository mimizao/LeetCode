#pragma clang diagnostic push
#pragma ide diagnostic ignored "readability-convert-member-functions-to-static"
#pragma ide diagnostic ignored "cppcoreguidelines-narrowing-conversions"
#pragma ide diagnostic ignored "cert-str34-c"

#include <iostream>
#include <vector>
#include <stack>

using namespace std;

class Solution {
public:
    int myMaximalRectangle(vector<vector<char>> &matrix) {
        int row = matrix.size();
        int cols = matrix[0].size();
        vector<vector<pair<int, pair<int, int>>>> dp(row, vector<pair<int, pair<int, int>>>(cols));
        dp[0][0] = pair<int, pair<int, int>>(matrix[0][0] - '0', pair<int, int>(1, 1));
        int res = matrix[0][0] - '0';
        for (int i = 1; i < row; i++) {
            if (dp[i - 1][0].first) {
                if (matrix[i][0] - '0') {
                    dp[i][0] = pair<int, pair<int, int>>(dp[i - 1][0].first + 1,
                                                         pair<int, int>(1, dp[i - 1][0].second.second + 1));
                } else {
                    dp[i][0] = pair<int, pair<int, int>>(0, pair<int, int>(0, 0));
                }
            } else {
                if (matrix[i][0] - '0') {
                    dp[i][0] = pair<int, pair<int, int>>(1, pair<int, int>(1, 1));
                } else {
                    dp[i][0] = pair<int, pair<int, int>>(0, pair<int, int>(0, 0));
                }
            }
            res = max(res, dp[i][0].first);
        }
        for (int i = 1; i < cols; i++) {
            if (dp[0][i - 1].first) {
                if (matrix[0][i] - '0') {
                    dp[0][i] = pair<int, pair<int, int>>(dp[0][i - 1].first + 1, pair<int, int>(
                            dp[0][i - 1].second.first + 1, 1));
                } else {
                    dp[0][i] = pair<int, pair<int, int>>(0, pair<int, int>(0, 0));
                }
            } else {
                if (matrix[0][i] - '0') {
                    dp[0][i] = pair<int, pair<int, int>>(1, pair<int, int>(1, 1));
                } else {
                    dp[0][i] = pair<int, pair<int, int>>(0, pair<int, int>(0, 0));
                }
            }
            res = max(res, dp[0][i].first);
        }
        for (int i = 1; i < row; i++) {
            for (int j = 1; j < cols; j++) {
                if (matrix[i][j] == '0') {
                    dp[i][j] = pair<int, pair<int, int>>(0, pair<int, int>(0, 0));
                    continue;
                }
                if (!dp[i - 1][j].first && !dp[i][j - 1].first) {
                    dp[i][j] = pair<int, pair<int, int>>(1, pair<int, int>(1, 1));
                } else if (dp[i - 1][j].first && !dp[i][j - 1].first) {
                    dp[i][j] = pair<int, pair<int, int>>(dp[i - 1][j].second.second + 1,
                                                         pair<int, int>(1, dp[i - 1][j].second.second + 1));
                } else if (!dp[i - 1][j].first && dp[i][j - 1].first) {
                    dp[i][j] = pair<int, pair<int, int>>(dp[i][j - 1].second.first + 1,
                                                         pair<int, int>(dp[i][j - 1].second.first + 1, 1));
                } else {
                    if (dp[i - 1][j - 1].first) {
                        dp[i][j] = pair<int, pair<int, int>>(
                                (dp[i - 1][j - 1].second.first + 1) * (dp[i - 1][j - 1].second.second + 1),
                                pair<int, int>(dp[i - 1][j - 1].second.first + 1, dp[i - 1][j - 1].second.second + 1));
                    } else {
                        dp[i][j] = dp[i - 1][j].second.second >= dp[i][j - 1].second.first ? pair<int, pair<int, int>>(
                                dp[i - 1][j].second.second + 1,
                                pair<int, int>(1, dp[i - 1][j].second.second + 1)) : pair<int, pair<int, int>>(
                                dp[i][j - 1].second.first + 1,
                                pair<int, int>(dp[i][j - 1].second.first + 1, 1));
                    }
                }
                cout << dp[i][j].first << endl;
                res = max(res, dp[i][j].first);
            }
        }
        return res;
    }

    int maximalRectangle(vector<vector<char>> &matrix) {
        int row = matrix.size();
        int col = matrix[0].size();
        vector<vector<int>> left(row, vector<int>(col, 0));

        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (matrix[i][j] == '1') {
                    left[i][j] = (j == 0 ? 0 : left[i][j - 1]) + 1;
                }
            }
        }

        int ret = 0;
        for (int j = 0; j < col; j++) {
            vector<int> up(row, 0), down(row, 0);

            stack<int> stk;
            for (int i = 0; i < row; i++) {
                while (!stk.empty() && left[stk.top()][j] >= left[i][j]) {
                    stk.pop();
                }
                up[i] = stk.empty() ? -1 : stk.top();
                stk.push(i);
            }
            stk = stack<int>();
            for (int i = row - 1; i >= 0; i--) {
                while (!stk.empty() && left[stk.top()][j] >= left[i][j]) {
                    stk.pop();
                }
                down[i] = stk.empty() ? row : stk.top();
                stk.push(i);
            }

            for (int i = 0; i < row; i++) {
                int height = down[i] - up[i] - 1;
                int area = height * left[i][j];
                ret = max(ret, area);
            }
        }
        return ret;
    }
};


int main() {
    Solution solution;
    vector<vector<char>> matrix;
    vector<char> row1{'0', '0', '1', '0'};
    vector<char> row2{'0', '0', '1', '0'};
    vector<char> row3{'0', '0', '1', '0'};
    vector<char> row4{'0', '0', '1', '1'};
    vector<char> row5{'0', '1', '1', '1'};
    vector<char> row6{'0', '1', '1', '1'};
    vector<char> row7{'1', '1', '1', '1'};
    matrix.push_back(row1);
    matrix.push_back(row2);
    matrix.push_back(row3);
    matrix.push_back(row4);
    int res = solution.maximalRectangle(matrix);
    std::cout << res << std::endl;
    return 0;
}

#pragma clang diagnostic pop