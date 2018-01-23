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
                new XDeclaration("0.1", "utf-8", "yes"),
                new XElement("AElename",
                new XComment("This is the AElemet Comment"), 
                new XAttribute("AEleAtriName","Atrribute Obj content"),
                new XElement("A1EleName","A1Content"
                    ),new XElement("A2EleName","A2Content")));
            XElement AEle = aDoc.Element("AElename");//这里设置好坑爹啊，完全不能输入错误的字符
            AEle.Add(new XElement("AddElem"));
            AEle.Add(new XAttribute("BAttri", "BAttriObj"));
            AEle.Add(new XComment("BComment Obj"));
            AEle.AddFirst(new XComment("AddFirstCommet"));
            AEle.Attribute("BAttri").Remove();

            aDoc.Add(new XProcessingInstruction("xml-stylesheet", @"href=""stories.css""type=""text/css"""));
            Console.WriteLine(aDoc);
            Console.ReadKey();
        }
    }
}
