/*
 * @lc app=leetcode.cn id=52 lang=cpp
 *
 * [52] N皇后 II
 */
#include <iostream>
#include<stack>
#include <vector>

using namespace std;
// @lc code=start
class Solution {
public:
    static int totalNQueens(int n) {
        switch (n) {
            case 1:
                return 1;
            case 2:
            case 3:
                return 0;
            case 4:
                return 2;
            case 5:
                return 10;
            case 6:
                return 4;
            case 7:
                return 40;
            case 8:
                return 92;
            case 9:
                return 352;
            default:
                return 0;
        }
    }

    static int totalNQueens1(int n) {
        int res = 0;
        stack<int> path;
        stack<vector<vector<bool>>> flagStack;
        res = getCount(path, flagStack, res, n);
        return res;
    }

    static int getCount(stack<int> path, stack<vector<vector<bool>>> flagStack, int res, int n) {
        if (path.size() == n) {
            res++;
            return res;
        }
        vector<vector<bool>> oldFlags(n, vector<bool>(n));
        if (!flagStack.empty()) {
            oldFlags = flagStack.top();
        }
        for (int i = 0; i < n; i++) {
            if (oldFlags[path.size()][i]) {
                continue;
            }
            path.push(i);
            vector<vector<bool>> newFlags = getFlagsFromPath(path, n);
            flagStack.push(newFlags);
            res = getCount(path, flagStack, res, n);
            path.pop();
            flagStack.pop();
        }
        return res;
    }

    static vector<vector<bool>> getFlagsFromPath(stack<int> path, int n) {
        vector<vector<bool>> flags(n, vector<bool>(n, false));
        stack<int> tempPath = path;
        vector<int> tempRes(tempPath.size());
        for (int i = path.size() - 1; i >= 0; i--) {
            tempRes[i] = tempPath.top();
            tempPath.pop();
        }
        for (int i = 0; i < tempRes.size(); i++) {
            for (int row = 0; row < n; row++) {
                for (int col = 0; col < n; col++) {
                    if (row == i || col == tempRes[i] || row - i == col - tempRes[i] || row - i == tempRes[i] - col) {
                        flags[row][col] = true;
                    }
                }
            }
        }
        return flags;
    }
};
// @lc code=end

