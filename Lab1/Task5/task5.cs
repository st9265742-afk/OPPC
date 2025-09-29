using System;

namespace Task5;

public class Program
{
    public static double GetAverage(int[] marks)
    {
        int sum = 0;
        foreach (int mark in marks)
            sum += mark;
        return (double)sum / marks.Length;
    }
    public static int GetMin(int[] marks)
    {
        int min = marks[0];
        foreach (int mark in marks)
            if (mark < min)
                min = mark;
        return min;
    }
    public static int GetMax(int[] marks)
    {
        int max = marks[0];
        foreach (int mark in marks)
            if (mark > max)
                max = mark;
        return max;
    }
    void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            int[] group = groups[i];
            double avg = GetAverage(group);
            int min = GetMin(group);
            int max = GetMax(group);

            Console.WriteLine($"Група {i + 1}:");
            Console.WriteLine($"Середня оцінка: {avg:F2}");
            Console.WriteLine($"Мінімальна оцінка: {min}");
            Console.WriteLine($"Максимальна оцінка: {max}");
            Console.WriteLine();
        }
    }
    public static void Main()
    {

    }
}