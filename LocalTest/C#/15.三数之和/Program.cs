// See https://aka.ms/new-console-template for more information

int[] nums = { -1, 0, 1, 2, -1, -4 };
IList<IList<int>> ans = ThreeSum(nums);

IList<IList<int>> ThreeSum(int[] nums)
{
    int len = nums.Length;
    List<List<int>> res = new List<List<int>>();
    if (len <= 2)
    {
        return (IList<IList<int>>)res;
    }
    Array.Sort(nums);
    for (int first = 0; first < len - 2; first++)
    {
        if (first != 0 && nums[first] == nums[first - 1])
        {
            continue;
        }
        int third = len - 1;
        int target = 0 - nums[first];
        for (int second = first + 1; second < len - 1; second++)
        {
            if (second != first + 1 && nums[second] == nums[second - 1])
            {
                continue;
            }
            while (second < third && nums[second] + nums[third] > target)
            {
                third--;
            }
            if (second == third)
            {
                break;
            }
            if (nums[second] + nums[third] == target)
            {
                res.Add(new List<int>() { nums[first], nums[second], nums[third] });
            }
        }
    }
    return (IList<IList<int>>)res;
}