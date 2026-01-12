using System; using System.Linq; using System.Xml.Linq;
class Program
{
    static void Main()
    {
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

        foreach(var x in over30)
            Console.WriteLine(x.Name + " (" + x.Age + ")");
    }
}
