using System;

namespace Task1
{
    public class Program
    {
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public static string GetMessage(int number)
        {
            if (IsEven(number))
                return "Двері відкриваються!";
            else
                return "Двері зачинені...";
        }
        public static void Main()
        {
            Console.WriteLine("Введіть число:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                string message = GetMessage(number);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Це не число!");
            }
        }
    }
}