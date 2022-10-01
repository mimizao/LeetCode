#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>

using namespace std;

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

int main() {
    Solution solution;
    auto res = solution.grayCode(8);
    return 0;
}
