int[] nums = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 13, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
int target = 13;
Solution solution = new Solution();
var res = solution.Search(nums, target);
Console.WriteLine(res);

public class Solution
{
    public bool Search1(int[] nums, int target)
    {
        Array.Sort(nums);
        int len = nums.Length;
        int begin = 0;
        int end = len - 1;
        while (begin <= end)
        {
            int mid = (begin + end) / 2;
            if (nums[mid] == target)
            {
                return true;
            }
            if (nums[mid] < target)
            {
                begin = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }
        return false;
    }

    public bool Search(int[] nums, int target)
    {
        int len = nums.Length;
        if (len == 1) return nums[0] == target;
        int begin = 0;
        int end = len - 1;
        while (begin <= end)
        {
            int mid = (begin + end) / 2;
            if (nums[mid] == target) return true;
            if (nums[begin] == nums[mid] && nums[mid] == nums[end])
            {
                begin++;
                end--;
            }
            else if (nums[begin] <= nums[mid])
            {
                if (nums[begin] <= target && target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    begin = mid + 1;
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[^1])
                {
                    begin = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
        }
        return false;
    }
}