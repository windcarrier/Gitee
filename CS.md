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

## 专题问题

### C#中Dynamic关键字

dynamic关键字和动态语言运行时（DLR）是.Net 4.0中新增的功能。

#### 什么是"动态"？

　　编程语言有时可以划分为静态类型化语言和动态类型化语言。C#和Java经常被认为是静态化类型的语言，而Python、Ruby和JavaScript是动态类型语言。

　　一般而言，动态语言在编译时不会对类型进行检查，而是在运行时识别对象的类型。这种方法有利有弊：代码编写起来更快、更容易，但无法获取编译器错误，只能通过单元测试和其他方法来确保应用正常运行。

　　C#最初是作为纯静态语言创建的，但是C#4添加了一些动态元素，用于改进与动态语言和框架之间的互操作性。C# 团队考虑了多种设计选项，但最终确定添加一个新关键字来支持这些功能：dynamic。

　　dynamic关键字可充当C#类型系统中的静态类型声明。这样，C#就获得了动态功能，同时仍然作为静态类型化语言而存在。

　　由于编译时不会去检查类型，所以导致IDE的IntellSense失效。

#### dynamic、Object还是Var？

那么，dynamic、Object和var之间的实际区别是什么？何时使用它们？

　　先说说var，经常有人会拿dynamic和var进行比较。实际上，var和dynamic完全是两个概念，根本不应该放在一起做比较。

　　var实际上编译器抛给我们的语法糖，一旦被编译，编译器就会自动匹配var变量的实际类型，并用实际类型来替换该变量的声明，等同于我们在编码时使用了实际类型声明。而dynamic被编译后是一个Object类型，编译器编译时不会对dynamic进行类型检查。

　　再说说Object，上面提到dynamic类型再编译后是一个Object类型，同样是Object类型，那么两者的区别是什么呢？

　　除了在编译时是否进行类型检查之外，另外一个重要的区别就是类型转化，这也是dynamic很有价值的地方，dynamic类型的实例和其他类型的实例间的转换是很简单的，开发人员能够很方便地在dyanmic和非dynamic行为间切换。任何实例都能隐式转换为dynamic类型实例，见下面的例子：

```C#
dynamic d1 = 7;
dynamic d2 = "a string";
dynamic d3 = System.DateTime.Today;
dynamic d4 = System.Diagnostics.Process.GetProcesses();

Conversely, an implicit conversion can be dynamically applied to any expression of type dynamic.
反之亦然，类型为dynamic的任何表达式也能够隐式转换为其他类型。
int i = d1;
string str = d2;
DateTime dt = d3;
System.Diagnostics.Process[] procs = d4;
```
