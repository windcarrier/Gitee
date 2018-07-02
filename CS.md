# C#语言记录——菜鸟初飞篇  
## 基础部分
**一些问题**
[ ] 事件  
[ ] LinQ
[ ] 异步  

### XML调用  
常用标签
+ XElement 一个单元节点
+ XComment 不参与编译 相当于注释 给人看的
+ XAttribute 节点属性
+ XDocument 一个XML文档的父节点
+ XDeclaration XML的文档声明 涵盖板板号，字符编码类型，是否引用外部数据
+ XProcessingInstruction 处理指令，由两个参数组成

XDocument aDoc = new XDocument();
aDoc.Save("SaveName.xml");//保存XML文件的函数  
```C#
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
```
### 异步编程  
C#5最新的async/await特性用来实现异步线程

#### 取消异步操作

#### 可删除的对象
实现IDisposable接口中的Dispose()方法。当不再需要某个对象时，调用这个方法，释放重要资源。  
还可以使用一种可以优化使用这个方法的结构。  
**using** 关键字可以在代码块中的初始化使用重要的资源的对象，并在这个代码块的末尾自动调用Dispose()方法。    
ClassName VariableName = new ClassName();
...
using (VariableName)
{
	SomeThing....
}  
#### 处理继承的关键词
**abstract** 只能被继承不能实例化  
**sealed** 实例化不能被继承  

### 仔细研究一下C#中的容器
