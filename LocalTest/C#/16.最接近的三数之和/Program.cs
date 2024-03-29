﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int ThreeSumClosest(int[] nums, int target)
{
    Array.Sort(nums);
    int res = nums[0] + nums[1] + nums[2];
    int difference = int.MaxValue;
    for (int first = 0; first < nums.Length - 2; first++)
    {
        if (first > 0 && nums[first] == nums[first - 1])
        {
            first++;
            continue;
        }
        int second = first + 1;
        int third = nums.Length - 1;
        while (third > second)
        {
            int newDifference = Math.Abs(nums[first] + nums[second] + nums[third]-target);
            if (newDifference < difference)
            {
                difference = newDifference;
                res = nums[first] + nums[second] + nums[third];
            }
            if (target > nums[first] + nums[second] + nums[third])
            {
                second++;
                while (second < third && nums[second] == nums[second + 1])
                {
                    second++;
                }
            }
            else
            {
                third--; 
                while(second < third && nums[third] == nums[third - 1])
                {
                    third--;
                }
            }
        }


    }


    return res;
}