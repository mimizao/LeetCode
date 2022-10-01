/*
 * @lc app=leetcode.cn id=89 lang=cpp
 *
 * [89] 格雷编码
 */
#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>
using namespace std;

// @lc code=start
class Solution {
public:
    vector<int> grayCode(int n) {
        vector<int> res{0, 1};
        for (int i = 1; i < n; i++) {
            vector<int> temp(res.size());
            reverse_copy(res.begin(), res.end(), temp.begin());
            for (int &j: temp) {
                j += (int) pow(2, i);
            }
            res.insert(res.end(), temp.begin(), temp.end());
        }
        return res;
    }
};
// @lc code=end

