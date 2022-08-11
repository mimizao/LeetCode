#include <iostream>
#include <vector>
#include <unordered_map>
using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        int len = nums.size();
        unordered_map<int,int> hashtable;
        for (int i = 0; i < len;i++){
            auto it = hashtable.find(target-nums[i]);
            if (it!=hashtable.end()){
                return {it->second,i};
            }
            hashtable[nums[i]]=i;
        }
        return {};
    }
};

int main() {
    std::cout << "Hello, World!" << std::endl;
    return 0;
}


