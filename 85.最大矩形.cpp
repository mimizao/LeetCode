/*
 * @lc app=leetcode.cn id=85 lang=cpp
 *
 * [85] 最大矩形
 */
#include <iostream>
#include <vector>
#include <stack>
using namespace std;

// @lc code=start
class Solution {
public:
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
// @lc code=end

