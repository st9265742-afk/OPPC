using System;

namespace Task4;

public class Program
{
    public static bool IsValidTriangle(double a, double b, double c)
    {
        return a > 0 && b > 0 && c > 0 &&
                   a + b > c && a + c > b && b + c > a;
    }
    public static double GetPerimeter(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
            throw new ArgumentException("Невалідний трикутник");
        return a + b + c;
    }
    public static double GetArea(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
            throw new ArgumentException("Невалідний трикутник");
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public static string GetTriangleType(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
            throw new ArgumentException("Невалідний трикутник");

        if (a == b && b == c)
            return "рівносторонній";

        if (a == b || a == c || b == c)
            return "рівнобедрений";

        double[] sides = { a, b, c };
        Array.Sort(sides);
        if (Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < 0.001)
            return "прямокутний";

        return "довільний";
    }
    public static void Main()
    {

    }
}
