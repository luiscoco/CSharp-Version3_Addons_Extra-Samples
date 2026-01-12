using System; using System.Collections.Generic;
static class EnumerableExtras
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source) where T : class
    {
        foreach(var x in source) if (x != null) yield return x;
    }
    public static IEnumerable<U> Map<T,U>(this IEnumerable<T> src, Func<T,U> f)
    {
        foreach(var x in src) yield return f(x);
    }
}
class Program
{
    static void Main()
    {
        var words = new string[]{ "hi", null, "there" };
        foreach(var w in words.WhereNotNull().Map(s => s.ToUpper()))
            Console.WriteLine(w);
    }
}
