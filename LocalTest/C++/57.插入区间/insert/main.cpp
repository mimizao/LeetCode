#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    static vector<vector<int>> insert(vector<vector<int>> &intervals, vector<int> &newInterval) {
        int len = intervals.size();
        vector<vector<int>> res;
        if (len == 0) {
            res.push_back(newInterval);
            return res;
        }
        if (newInterval[0] > intervals[len - 1][1]) {
            intervals.push_back(newInterval);
            return intervals;
        }
        int index = -1;
        for (int i = 0; i < len; i++) {
            if (newInterval[0] > intervals[i][1]) {
                res.push_back(intervals[i]);
                index = i;
                continue;
            }
            vector<int> temp;
            temp.push_back(min(newInterval[0], intervals[i][0]));
            if (newInterval[1] <= intervals[i][1] && newInterval[0] > intervals[i][0]) {
                temp.push_back(intervals[i][1]);
                res.push_back(temp);
                index = i + 1;
                break;
            }
            for (int j = i; j < len; j++) {
                if (newInterval[1] < intervals[j][0]) {
                    temp.push_back(newInterval[1]);
                    res.push_back(temp);
                    index = j;
                    break;
                } else if (newInterval[1] > intervals[j][1] && j != len - 1) {
                    continue;
                } else if (newInterval[1] > intervals[j][1] && j == len - 1) {
                    temp.push_back(newInterval[1]);
                    res.push_back(temp);
                    return res;
                } else if (newInterval[1] >= intervals[j][0] || newInterval[1] == intervals[j][1]) {
                    temp.push_back(max(newInterval[1], intervals[j][1]));
                    res.push_back(temp);
                    index = j + 1;
                    break;
                } else {

                }
            }
            break;
        }
        if (index == len + 1) {
            intervals.push_back(newInterval);
            return intervals;
        }
        for (int i = index; i < len; i++) {
            res.push_back(intervals[i]);
        }
        return res;
    }

    static vector<vector<int>> insert1(vector<vector<int>> &intervals, vector<int> &newInterval) {
        vector<vector<int>> res;
        int len = intervals.size();
        int index = 0;
        while (index < len && intervals[index][1] < newInterval[0]) {
            res.push_back(intervals[index]);
            index++;
        }
        while (index < len && intervals[index][0] <= newInterval[1]) {
            newInterval[0] = min(intervals[index][0], newInterval[0]);
            newInterval[1] = max(intervals[index][1], newInterval[1]);
            index++;
        }
        res.push_back(newInterval);
        while (index < len) {
            res.push_back(intervals[index]);
            index++;
        }
        return res;
    }
};

int main() {
    vector<vector<int>> intervals = {{1, 5}};
    vector<int> newInterval = {0, 0};
    auto res = Solution::insert(intervals, newInterval);
    auto res1 = Solution::insert1(intervals, newInterval);
    return 0;
}
