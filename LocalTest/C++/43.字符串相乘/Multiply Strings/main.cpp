#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    static string multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0")return "0";
        int len1 = num1.size();
        int len2 = num2.size();
        auto resArr = vector<int>(len1 + len2);
        for (int i = len1 - 1; i >= 0; i--) {
            int x = num1[i] - '0';
            for (int j = len2 - 1; j >= 0; j--) {
                int y = num2[j] - '0';
                resArr[i + j + 1] += x * y;
            }
        }

        for (int i = len1 + len2 - 1; i > 0; i--) {
            resArr[i - 1] += resArr[i] / 10;
            resArr[i] %= 10;
        }
        int index = resArr[0] == 0 ? 1 : 0;
        string res;
        while (index < len1 + len2) {
            res.push_back(resArr[index]);
            index++;
        }
        for (auto &c: res) {
            c += '0';
        }
        return res;
    }
};

int main() {
    string num1 = "21198555069473058372905";
    string num2 = "38205872058205872";
    Solution solution;
    string res = solution.multiply(num1, num2);
    std::cout << res << std::endl;
    return 0;
}
