// See https://aka.ms/new-console-template for more information
int[] nums ={0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
int res = RemoveDuplicates(nums);
Console.WriteLine(res);


int RemoveDuplicates(int[] nums)
{
    int len = nums.Length;
    if (len <= 1)
    {
        return len;
    }
    int res = len;
    int left = 0;
    int right = 1;
    while (right < len)
    {
        if (nums[left] >= nums[right])
        {
            if (nums[left] == nums[len - 1])
            {
                System.Console.WriteLine(right);
                return right;
            }
            int index = right;
            while (index < len - 1)
            {
                if (nums[index] > nums[left] && nums[index] > nums[right])
                {
                    break;
                }
                else
                {
                    index++;
                }
            }
            nums[right] = nums[index];
            res--;
        }
        left++;
        right++;
    }
    return res;
}