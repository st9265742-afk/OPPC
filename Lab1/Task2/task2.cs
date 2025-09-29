using System;

namespace Task2
{
    public class Program
    {
        private static Random random = new Random();
        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(min, max + 1);
            }
            return array;
        }
        public static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int value in numbers)
            {
                sum += value;
            }
            return sum;
        }
        public static double GetAverage(int[] numbers)
        {
            return (double)GetSum(numbers) / numbers.Length;
        }
        public static int GetMin(int[] numbers)
        {
            int min = numbers[0];
            foreach (int value in numbers)
            {
                if (value < min)
                    min = value;
            }
            return min;
        }
        public static int GetMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int value in numbers)
            {
                if (value > max)
                    max = value;
            }
            return max;
        }
        public static void Main()
        {

        }
    }
}