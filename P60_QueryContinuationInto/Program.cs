using System; using System.Linq; using System.Collections.Generic;
class Program
{
    static void Main()
    {
        var nums = new List<int>{ 1,2,3,4,5,6,7,8 };
        var query = from n in nums
                    group n by n % 3 into g
                    where g.Key != 0
                    select new { Remainder = g.Key, Items = g.OrderByDescending(x=>x) };

        foreach(var bucket in query)
        {
            Console.WriteLine("Remainder " + bucket.Remainder + ": " + string.Join(",", bucket.Items));
        }
    }
}
