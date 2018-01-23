using System;
using System.Xml.Linq;
using System.IO;
namespace A01XML
{
    class XMLTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World_MY computer first C# test");
            Console.ReadKey();
            Console.WriteLine();
            
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
            Console.WriteLine(aDoc.ToString());
            Console.WriteLine(aDoc.ToString());
            //这里会发现好神奇Declaration中的内容是打不出来的，
            //必须采用以下的方法才能将Declaration的内容打印出来
            Console.ReadKey();
            var sw = new StringWriter();
            aDoc.Save(sw);
            string aResult = sw.GetStringBuilder().ToString();
            Console.WriteLine("******************************");
            Console.WriteLine(aResult);
            Console.ReadKey();
            aDoc.Save("TestXML.xml");
        }
    }
}
