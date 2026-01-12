using System; using System.Linq; using System.Collections.Generic;
class Person { public int Id { get; set; } public string Name { get; set; } }
class Order { public int PersonId { get; set; } public string Item { get; set; } }
class Program
{
    static void Main()
    {
        var people = new List<Person> {
            new Person{Id=1, Name="Ana"},
            new Person{Id=2, Name="Bob"},
            new Person{Id=3, Name="Cara"}
        };
        var orders = new List<Order> {
            new Order{PersonId=1, Item="Book"},
            new Order{PersonId=1, Item="Pen"},
            new Order{PersonId=2, Item="Pencil"}
        };

        // Inner join
        var inner = from p in people
                    join o in orders on p.Id equals o.PersonId
                    select new { p.Name, o.Item };
        Console.WriteLine("Inner join:");
        foreach(var x in inner) Console.WriteLine("  " + x.Name + " -> " + x.Item);

        // Group join (left-outer-like)
        var groupJoin = from p in people
                        join o in orders on p.Id equals o.PersonId into og
                        select new { p.Name, Items = og };
        Console.WriteLine("\nGroup join:");
        foreach(var g in groupJoin)
        {
            Console.WriteLine("  " + g.Name + ": " + string.Join(",", g.Items.Select(t=>t.Item)));
        }
    }
}
