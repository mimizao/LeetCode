using System;
/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int len = nums1.Length + nums2.Length;
        if (len % 2 == 1)
        {
            return GetKthElement(nums1, nums2, len / 2 + 1);
        }
        else
        {
            return (GetKthElement(nums1, nums2, len / 2) + GetKthElement(nums1, nums2, len / 2 + 1)) / 2.0;
        }
    }

    public int GetKthElement(int[] nums1, int[] nums2, int k)
    {
        int index1 = 0;
        int index2 = 0;
        while (true)
        {
            if (index1 == nums1.Length)
            {
                return nums2[index2 + k - 1];
            }
            if (index2 == nums2.Length)
            {
                return nums1[index1 + k - 1];
            }
            if (k == 1)
            {
                return Math.Min(nums1[index1], nums2[index2]);
            }
            int newIndex1 = Math.Min(index1 + k / 2, nums1.Length) - 1;
            int newIndex2 = Math.Min(index2 + k / 2, nums2.Length) - 1;
            if (nums1[newIndex1] <= nums2[newIndex2])
            {
                k -= (newIndex1 - index1 + 1);
                index1 = newIndex1 + 1;
            }
            else
            {
                k -= (newIndex2 - index2 + 1);
                index2 = newIndex2 + 1;
            }
        }
    }
}
// @lc code=end

