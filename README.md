# C# 3.0 - Additional Samples

Extra demos that dive deeper into C# 3.0 beyond the core set (P57-P64). Each project is a focused, runnable example with a short, isolated idea.

## Build and run
```bash
dotnet restore
dotnet build
dotnet run --project P57_ImplicitlyTypedArrays
```
All projects target .NET 10.0 with `<LangVersion>3</LangVersion>`.

## Projects

### P57_ImplicitlyTypedArrays
Demonstrates how `new[] { ... }` infers the best common element type at compile time.
```csharp
var ints = new[] { 1, 2, 3 };          // int[]
var doubles = new[] { 1.0, 2, 3.5 };   // double[]
var strings = new[] { "a", "b", null };// string[]
Console.WriteLine(ints.GetType().Name);
Console.WriteLine(doubles.GetType().Name);
Console.WriteLine(strings.GetType().Name);
```

### P58_LINQJoins
Shows inner joins and group joins, including a left-outer-like projection.
```csharp
var inner = from p in people
            join o in orders on p.Id equals o.PersonId
            select new { p.Name, o.Item };

var groupJoin = from p in people
                join o in orders on p.Id equals o.PersonId into og
                select new { p.Name, Items = og };
```

### P59_LINQOrderLet
Uses `let` to compute a value once, then sorts by multiple keys.
```csharp
var query = from w in words
            let len = w.Length
            orderby len ascending, w descending
            select new { w, len };
```

### P60_ClosuresAndCapturedVariables
Illustrates the classic C# 3.0 closure-capture pitfall and a simple fix.
```csharp
foreach (int i in new int[]{1,2,3})
    actions.Add(() => Console.WriteLine("Captured i = " + i));

foreach (int j in new int[]{1,2,3})
{
    int local = j;
    fixedActions.Add(() => Console.WriteLine("Fixed local = " + local));
}
```

### P61_ExpressionTreesVsDelegates
Compares a delegate vs. an expression tree and performs a tiny rewrite.
```csharp
Func<int,int> f = x => x + 1;
Expression<Func<int,int>> e = x => x + 1;

var param = e.Parameters[0];
var replaced = new ReplaceVisitor(param, Expression.Constant(10));
var body = replaced.Visit(e.Body);
var newExpr = Expression.Lambda<Func<int>>(body);
```

### P62_ExtensionMethodsGenerics
Implements generic extension methods and chains them fluently.
```csharp
public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source) where T : class
{
    foreach (var x in source) if (x != null) yield return x;
}

foreach (var w in words.WhereNotNull().Map(s => s.ToUpper()))
    Console.WriteLine(w);
```

### P63_LinqToXml
Builds an XML document in-memory, then queries it with LINQ.
```csharp
var doc = new XDocument(
    new XElement("people",
        new XElement("person", new XAttribute("name","Ana"), new XAttribute("age","30")),
        new XElement("person", new XAttribute("name","Bob"), new XAttribute("age","25")),
        new XElement("person", new XAttribute("name","Cara"), new XAttribute("age","35"))
    )
);

var over30 = from p in doc.Root.Elements("person")
             let age = (int)p.Attribute("age")
             where age >= 30
             orderby (string)p.Attribute("name")
             select new { Name = (string)p.Attribute("name"), Age = age };
```

### P64_QueryContinuationInto
Uses `into` to continue a query after grouping and then filters/reshapes.
```csharp
var query = from n in nums
            group n by n % 3 into g
            where g.Key != 0
            select new { Remainder = g.Key, Items = g.OrderByDescending(x => x) };
```
