using System;
class Program
{
    static void Main()
    {
        var ints = new[] { 1, 2, 3 };          // int[]
        var doubles = new[] { 1.0, 2, 3.5 };   // double[] (common type inference)
        var strings = new[] { "a", "b", null };// string[] (nullable element)
        Console.WriteLine(ints.GetType().Name);
        Console.WriteLine(doubles.GetType().Name);
        Console.WriteLine(strings.GetType().Name);
    }
}
