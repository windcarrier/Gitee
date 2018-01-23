using System;
using System.Xml.Linq;
namespace A01XML
{
    class XMLTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World_MY computer first C# test");
            Console.ReadKey();
            XDocument aDoc = new XDocument(
                new XElement("AElename",
                new XComment("This is the AElemet Comment"), 
                new XAttribute("AEleAtriName","Atrribute Obj content"),
                new XElement("A1EleName","A1Content"
                    ),new XElement("A2EleName","A2Content")));
            Console.WriteLine(aDoc);
            Console.ReadKey();
        }
    }
}
