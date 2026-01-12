using System; using System.Linq; using System.Collections.Generic;
class Program
{
    static void Main()
    {
        var words = new List<string>{ "pear", "apple", "banana", "plum", "apricot" };

        var query = from w in words
                    let len = w.Length
                    orderby len ascending, w descending
                    select new { w, len };

        foreach(var x in query)
            Console.WriteLine(x.w + " (" + x.len + ")");
    }
}
