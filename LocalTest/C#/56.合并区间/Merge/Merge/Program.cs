Console.WriteLine("Hello, World!");

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        var len = intervals.Length;
        if (len == 1) return intervals;
        Array.Sort(intervals, (interval1, interval2) => interval1[0] - interval2[0]);
        var merged = new List<int[]>();
        foreach (var interval in intervals)
        {
            var start = interval[0];
            var end = interval[1];
            if (merged.Count == 0 || merged[^1][1] < start)
                merged.Add(new[] { start, end });
            else
                merged[^1][1] = Math.Max(merged[^1][1], end);
        }
        return merged.ToArray();
    }
}