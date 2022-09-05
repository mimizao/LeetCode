#include <iostream>

using namespace std;

class Solution {
public:
    bool isNumber(string s) {
        int eCount = 0;
        int numCount = 0;
        int spotCount = 0;
        bool flag = false;
        int len = s.size();
        if ((len == 1 && s[0] == '.') || s[0] == 'e' || s[0] == 'E' || s[len - 1] == 'e' || s[len - 1] == 'E' ||
            s[len - 1] == '+' ||
            s[len - 1] == '-') {
            return false;
        }
        for (int i = 0; i < len; i++) {
            if (s[i] - 'A' >= 0 && s[i] - 'Z' <= 0 && s[i] != 'E') {
                return false;
            } else if (s[i] - 'a' >= 0 && s[i] - 'z' <= 0 && s[i] != 'e') {
                return false;
            } else if (s[i] == 'E' || s[i] == 'e') {
                flag = true;
                eCount++;
                if (eCount > 1) {
                    return false;
                }
            } else if (s[i] == '.') {
                if (flag) {
                    return false;
                }
                spotCount++;
                if (spotCount > 1) {
                    return false;
                }
                if (i == 0 && i < len - 1 && (s[i + 1] == 'e' || s[i + 1] == 'E')) {
                    return false;
                }
            } else if (s[i] == '-' || s[i] == '+') {
                if (i > 0 && i < len - 1 &&
                    (s[i - 1] == '-' || s[i - 1] == '+' || s[i + 1] == '-' || s[i + 1] == '+')) {
                    return false;
                }
                if (i > 0 && (s[i - 1] != 'e' || s[i - 1] == 'E')) {
                    return false;
                }
                if (i < len - 1 && (s[i + 1] == 'e' || s[i + 1] == 'E')) {
                    return false;
                }
            } else if (s[i] - '0' >= 0 && s[i] - '9' <= 0) {
                numCount++;
            }
        }
        if (numCount == 0) {
            return false;
        }
        return true;
    }
};


int main() {
    Solution solution;
    string s = "-90E3";
    bool res = solution.isNumber(s);
    std::cout << res << std::endl;
    return 0;
}
