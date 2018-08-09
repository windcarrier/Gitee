# Note

## C# Basic

### 基类与子类的转换

子类可以无条件转换成基类（或者使用子类构造函数实例化基类），但只能调用基类的方法，但是实际的Type任然为子类，此时如果将转换后的基类强制转换为子类，可以转换。

基类不能够无条件转换成子类，如果强制转换，会报异常。

## .NET Core

> 包的依赖管理和托管 .NET Core 内容还有很多问题。

### 简介

.NET Core是一个通用开发平台，支持Windows MacOS和Linux,并且可用于设备、云和嵌入式/IoT方案。  
.NET Core有以下优势：

+ 部署灵活： 可以包含在应用或已安装的并行用户或计算机范围中。
+ 跨平台： 可以在 Windows、macOS 和 Linux 上运行；也可移植到其他操作系统。 Microsoft、其他公司和个人提供的支持的操作系统 (OS)、CPU 和应用程序方案会随着时间推移而增多。
+ 命令行工具： 可在命令行中执行所有产品方案。
+ 兼容性：.NET Core 通过 .NET 标准与 .NET Framework、Xamarin 和 Mono 兼容。
+ 开放源：.NET Core 是一个开放源平台，使用 MIT 和 Apache 2 许可证。 文档由 CC-BY 许可发行。 .NET Core 是一个 .NET Foundation 项目。
+ 由 Microsoft 支持：.NET Core 由 Microsoft 依据 .NET Core 支持提供支持  

### 撰写

+ .NET 运行时：提供类型系统、程序集加载、垃圾回收器、本机互操作和其他基本服务。
+ 一组 框架库：提供基元数据类型、应用编写类型和基本实用程序。
+ 一组 SDK 工具和语言编译器（Roslyn 和 F#）：提供基本的开发人员体验，可用于 .NET Core SDK。
+ “dotnet”应用主机，用于启动 .NET Core 应用。 它选择运行时并托管运行时，提供程序集加载策略来启动应用。 同一主机还可用于以大致相同的方式启动 SDK 工具。

### 语言

C#、Visual Basic、F#都可以适用于.NET Core的应用程序。  
Visual Studio、VisualcStudio Core、Vim。这种集成由[OmniSharp 项目](http://www.omnisharp.net/)和[Ionide](http://ionide.io/)的高手提供。

### NET API 和兼容性

可将 .NET Core 看作是 .NET Framework 在 .NET Framework 基类库 (BCL) 的跨平台版本。 它实施 .NET 标准规范。 .NET Core 提供了一个可用于 .NET Framework 或 Mono/Xamarin 的 API 子集。 在某些情况下，类型未完全实现（某些成员不可用或已移动）。  
有关 .NET Core API 的详细信息，请参阅 [.NET Core roadmap](https://github.com/dotnet/core/blob/master/roadmap.md)（.NET Core API 产品系列）。

### 与 .NET Standard 的关系

.NET Standard是一种 API 规范，用于描述开发者可以在每个 .NET 实现代码中使用的一组一致 .NET API。 .NET 实现需要实现此规范才能被视为符合 .NET Standard ，并且才能支持面向 .NET Standard 的库。
由于 .NET Core 可实现 .NET Standard，因此也支持 .NET Standard 库。

### Workload

就本身而言，.NET Core 包括单个应用程序模型（控制台应用），这对工具、本地服务和基于文本的游戏很有用。 除 .NET Core 外，还生成了其他应用程序模型以扩展其功能，例如：

+ [ASP.NET Core](https://docs.microsoft.com/zh-cn/aspnet/core/)
+ [Windows 10 通用 Windows 平台 (UWP)](https://developer.microsoft.com/windows)
+ [面向 UWP 时的 Xamarin.Forms](https://www.xamarin.com/forms)

### 开源

.NET Core 属于开放源（MIT 许可证），由 Microsoft 于 2014 年提供给 [.NET Foundation](https://dotnetfoundation.org/)。 现在它是最活跃的 .NET Foundation 项目之一。 可由个人和企业自由采用，包括用于个人、学术或商业目的。 许多公司已使用 .NET Core 作为应用、工具、新平台和托管服务的一部分。 其中某些公司对 GitHub 上的 .NET Core 做出了巨大贡献，并作为 [.NET Foundation Technical Steering Group](https://dotnetfoundation.org/blog/tsg-welcome)（.NET Foundation 技术控制组）的成员，指导产品方向。

### 与其他 .NET 实现比较

#### 与 .NET Framework 比较

.NET 由 Microsoft 于 2000 年首次发布，而后发展至今。 15 年多以来，.NET Framework 一直是 Microsoft 出品的主要 .NET 实现。  
.NET Core 和 .NET Framework 的主要差异在于：

+ 应用模型 -- .NET Core 不支持所有 .NET Framework 应用模型，某种程度上是因为其中许多模型都是基于 Windows 技术，如 WPF（基于 DirectX 生成）。 但 .NET Core 和 .NET Framework 两者都支持控制台和 ASP.NET Core 应用模型。
+ API -- .NET Core 包含很多与 .NET Framework 相同，但数量较少的 API，并且具有不同的组成要素（程序集名称不同；关键用例中的类型形状不同）。 目前，这些差异通常都需要更改，以将源移植到 .NET Core。 .NET Core 实现 .NET 标准 API，随着时间的推移，将包含更多 .NET Framework BCL API。
+ 子系统 -- .NET Core 实现 .NET Framework 中子系统的子级，目的是实现更简单的实现和编程模型。 例如，不支持代码访问安全性 (CAS)，但支持反射。
+ 平台 -- .NET Framework 支持 Windows 和 Windows Server，而 NET Core 还支持 macOS 和 Linux。
+ 开放源 -- .NET Core 属于开放源，而 .NET Framework 的只读子集属于开放源。

虽然 .NET Core 是唯一的且与 .NET Framework 和其他 .NET 实现大不相同，但使用源或二进制共享技术分享代码仍很简单。

#### 与 Mono 比较

Mono 是原始的跨平台和开放源 .NET 实现，于 2004 年首次发布。 可以把它看作是 .NET Framework 的社区克隆。 Mono 项目团队依赖于 Microsoft 发布的开放 .NET 标准（尤其是 ECMA 335），以便实现兼容性。  
.NET Core 和 Mono 的主要差异在于：

+ 应用模型 -- Mono 通过 Xamarin 产品支持 .NET Framework 应用模型（例如，Windows Forms）和其他应用模型（例如，Xamarin.iOS）的子集。 而 .NET Core 不支持这些内容。
+ API -- Mono 使用相同程序集名称和组成要素支持 .NET Framework API 的 大型子集。
+ 平台 -- Mono 支持很多平台和 CPU。
+ 开放源 -- Mono 和 .NET Core 两者都使用 MIT 许可证，且都属于 .NET Foundation 项目。
+ 焦点 --最近几年，Mono 的主要焦点是移动平台，而 .NET Core 的焦点是云工作负荷。

### VS Core & .NET Core HelloWorld

#### VSCore生成控制台程序

(1) 使用VS Core中资源管理器中的“打开文件夹”打开文件的工作目录
(2) 使用控制台进入所在工作目录，输入"dotnet new console"，建立一个新的工作台程序
(3) 此命令会在工作目录下创建Program.cs文件，以及HelloWorld.csproj的C#项目文件。
(4) 对于.NET Core 1.X 需要键入"dotnet restore" ，使有权限风闻所需的.NET Core包，后续版本不需要
(5) 键入"dotnet run"运行程序

#### 使用CLI实现HelloWorld

1. $ dotnet new console  
 生成一个Hello.csproj项目文件，其中包含生产控制台应用所必需的依赖项。它还将创建Program.cs，这是包含应用程序入口点的基本文件。

2. $ dotnet restore
 dotnet restore 调用到 [NuGet](https://www.nuget.org/)（.NET 包管理器）以还原依赖项树。 NuGet 分析 Hello.csproj 文件、下载文件中所述的依赖项（或从计算机缓存中获取）并编写 obj/project.assets.json 文件。 需要 project.assets.json 文件才可进行编译和运行。
 project.assets.json 文件是 NuGet 依赖项和其他描述应用的信息的持久化完整图片集。 此文件由其他工具（如 dotnet build 和 dotnet run）读取，让它们可以使用正确的 NuGet 依赖项和绑定解决方法集处理源代码。

3. $ dotnet run
 dotnet run 调用 dotnet build 来确保已生成要生成的目标，然后调用 dotnet <assembly.dll> 运行目标应用程序。  
 或者，还可以执行 dotnet build 来编译代码，无需运行已生成的控制台应用程序。 这使得编译的应用程序（作为 DLL 文件）可以在 Windows 上使用 dotnet bin\Debug\netcoreapp1.0\Hello.dll 运行（将 / 用于非 Windows 系统）。 还可以对应用程序指定参数，相关操作将在本主题稍后部分进行介绍。
 在高级方案中，可以将应用程序作为独立的特定于平台的文件集生成，该应用程序可以在未安装 .NET Core 的计算机上部署或运行。 请参阅 [.NET Core 应用程序部署](https://docs.microsoft.com/zh-cn/dotnet/core/deploying/index)了解详细信息。

请注意，以上过程中用来运行应用程序的命令和步骤仅用于开发过程。 准备好部署应用后，需要查看适用于 .NET Core 应用的不同[部署策略](https://docs.microsoft.com/zh-cn/dotnet/core/deploying/index)和 dotnet publish 命令。

参考：**[.NET Core CLI 命令](https://docs.microsoft.com/zh-cn/dotnet/core/tools/index)**

### .NET Core命令组织和测试项目

#### .NET Core文件组织

典型的组织类型  

```File Organizing
/NewTypes
|__/src
   |__/NewTypes
      |__/Pets
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__NewTypes.csproj
```

#### 测试示例

NewTypes 项目已准备就绪，与宠物相关的类型均置于一个文件夹中，因此具有良好的组织。 接下来，创建测试项目，并使用 [xUnit](https://xunit.github.io/) 测试框架开始编写测试。 使用单元测试，可自动检查宠物类型的行为，确认其正常运行。  
创建 test 文件夹，并在其中包含一个 NewTypesTests 文件夹。 在 NewTypesTests 文件夹的命令提示符中，执行 **dotnet new xunit**。这将生成两个文件：NewTypesTests.csproj 和 UnitTest1.cs。  
新建的试项目当前无法测试 NewTypes 中的类型，并且需要对 NewTypes 项目的项目引用。 要添加项目引用，请使用 **dotnet add reference** 命令。

```console
dotnet add reference ../../src/NewTypes/NewTypes.csproj
```

也可以通过在NewTypesTests.csproj文件中添加\<ItemGroup>节点，手动添加项目引用。

```xml
<ItemGroup>
  <ProjectReference Include="../../src/NewTypes/NewTypes.csproj" />
</ItemGroup>
```

NewTypesTests.csproj 文件包含下列内容：

+ 对 .NET 测试基础结构 Microsoft.NET.Test.Sdk 的包引用
+ 对 xUnit 测试框架 xunit 的包引用
+ 对测试运行程序 xunit.runner.visualstudio 的包引用
+ 对要测试的代码 NewTypes 的项目引用

下面为整个程序的目录结构  

```File Organizing
/NewTypes
|__/src
   |__/NewTypes
      |__/Pets
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__NewTypes.csproj
|__/test
   |__NewTypesTests
      |__PetTests.cs
      |__NewTypesTests.csproj
```

**NOTES:**  
尽管期望 expected 和 actual 值相等，但使用 Assert.NotEqual 检查的初始断言表明它们并不相等。 务必使最初创建的测试失败一次，以检查测试的逻辑是否正确。 这是测试驱动设计 (TDD) 方法中的一个重要步骤。 在确认测试失败后，调整断言使测试通过。

### 使用跨平台工具开发

此处介绍如何使用跨平台CLI工具编写.NET的库。CLI提供可跨任何支持OS工作的简化体验。

#### 面向 .NET Standard

如果对 .NET Standard 不是很熟悉，请参阅 [.NET Standard](https://docs.microsoft.com/zh-cn/dotnet/standard/net-standard) 了解详细信息。文章中含有一个表格，提供了各个版本各种实现的对应。  
以下是此表格对于创建库的意义：  
选择 .NET Standard 版本时，需要在能够访问最新 API 与能够定位更多 .NET 实现代码和 .NET Standard 版本之间进行权衡。 通过选择 netstandardX.X 版本（其中 X.X 是版本号）并将其添加到项目文件（.csproj 或 .fsproj），控制可面向的平台和版本范围。

面向 .NET Standard 时，有三种主要选项，具体取决于你的需求。

1. 可使用 .NET Standard 的默认版本，该版本由 netstandard1.4 模板提供，可提供对 .NET Standard 上大多数 API 的访问权限，同时仍与 UWP、.NET Framework 4.6.1 和即将推出的 .NET Standard 2.0 兼容。
2. .NET Standard 版本可后向兼容。 这意味着 netstandard1.0 库可在 netstandard1.1 平台以及更高版本上运行。 但是，不可向前兼容，即版本较低的 .NET Standard 平台无法引用版本较高的平台。 这意味着 netstandard1.0 库不能引用面向 netstandard1.1 或更高版本的库。 选择适合所需、恰当混合有 API 和平台支持的 Standard 版本。 目前，我们建议 netstandard1.4。
3. 如果希望面向 .NET Framework 版本 4.0 或更低版本，或者要使用 .NET Framework 中提供但 .NET Standard 中不提供的 API（例如 System.Drawing），请阅读以下部分，了解如何设定多目标。

#### 面向多目标

如果项目同时支持 .NET Framework 和 .NET Core，可能需要面向较旧版本的 .NET Framework。 在此方案中，如果要为较新目标使用较新的 API 和语言构造，请在代码中使用 **#if** 指令。 可能还需要为要面向的每个平台添加不同的包和依赖项，以包含每种情况所需的不同 API。  
例如，假设有一个库，它通过 HTTP 执行联网操作。 对于 .NET Standard 和 .NET Framework 版本 4.5 或更高版本，可从 System.Net.Http 命名空间使用 HttpClient 类。 但是，.NET Framework 的早期版本没有 HttpClient 类，因此可对早期版本使用 System.Net 命名空间中的 WebClient 类。
项目文件可能如下所示：

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>netstandard1.4;net40;net45</TargetFrameworks>
  </PropertyGroup>

  <!-- Need to conditionally bring in references for the .NET Framework 4.0 target -->
  <ItemGroup Condition="'$(TargetFramework)' == 'net40'">
    <Reference Include="System.Net" />
  </ItemGroup>

  <!-- Need to conditionally bring in references for the .NET Framework 4.5 target -->
  <ItemGroup Condition="'$(TargetFramework)' == 'net45'">
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Threading.Tasks" />
  </ItemGroup>
</Project>
```

在此处可看到三项主要更改：

+ TargetFramework 节点已替换为 TargetFrameworks，其中表示了三个 TFM。
+ net40 目标有一个 \<ItemGroup> 节点，拉取一个 .NET Framework 引用。
+ net45 目标中有一个 \<ItemGroup> 节点，拉取两个 .NET Framework 引用。

生成系统可识别以下用在 **#if** 指令中的处理器符号：

.NET Framework：NET20, NET35, NET40, NET45, NET451, NET452, NET46, NET461, NET462, NET47, NET471, NET472  
.NET Standard： NETSTANDARD1_0, NETSTANDARD1_1, NETSTANDARD1_2, NETSTANDARD1_3, NETSTANDARD1_4, NETSTANDARD1_5, NETSTANDARD1_6, NETSTANDARD2_0  
.NET Core： NETCOREAPP1_0, NETCOREAPP1_1, NETCOREAPP2_0, NETCOREAPP2_1

如果使用多版本编译，则编译后会在bin目录下生成多个版本的编译结果。

#### 在 .NET Core 上测试库  

能够跨平台进行测试至关重要。 可使用现成的 xUnit 或 MSTest。 它们都十分适合在 .NET Core 上对库进行单元测试。 如何使用测试项目设置解决方案取决于解决方案的结构。 下面的示例假设测试和源目录位于同一顶级目录下。

1.设置解决方案。 可使用以下命令实现此目的：

```bash
 mkdir SolutionWithSrcAndTest
 cd SolutionWithSrcAndTest
 dotnet new sln
 dotnet new classlib -o MyProject
 dotnet new xunit -o MyProject.Test
 dotnet sln add MyProject.Test/MyProject.Test.csproj
 dotnet sln add MyProject/MyProject.csproj
```

这将创建多个项目，并一个解决方案中将这些项目链接在一起。 SolutionWithSrcAndTest 的目录应如下所示：

```File Organizing
/SolutionWithSrcAndTest
|__SolutionWithSrcAndTest.sln
|__MyProject/
|__MyProject.Test/
```

2.导航到测试项目的目录，然后添加对 MyProject 中的 MyProject.Test 的引用。

```bash
cd MyProject.Test
dotnet add reference ../MyProject/MyProject.csproj
```

3.还原包和生成项目：

```bash
dotnet restore
dotnet build
```

4.执行dotnet test 命令，验证xUnit是否在运行。如果选用MSTest，则应改为MSTest控制台运行程序。

#### 使用多个项目

对于较大的库，通常需要将功能置于不同项目中。
假设要生成一个可以惯用的 C# 和 F# 使用的库。 这意味着库的使用者可通过对 C# 或 F# 来说很自然的方式来使用它们。 例如，在 C# 中，了能会这样使用库：

这样的使用方案意味着被访问的 API 必须具有用于 C# 和 F# 的不同结构。 通常的方法是将库的所有逻辑因子转化到核心项目中，C# 和 F# 项目定义调用到核心项目的 API 层。 该部分的其余部分将使用以下名称：

+ AwesomeLibrary.Core - 核心项目，其中包含库的所有逻辑
+ AwesomeLibrary.CSharp - 具有打算在 C# 中使用的公共 API 的项目
+ AwesomeLibrary.FSharp - 具有打算在 F# 中使用的公共 API 的项目

可在终端运行下列命令，生成下列指南的结构：

```bash
mkdir AwesomeLibrary && cd AwesomeLibrary
dotnet new sln
mkdir AwesomeLibrary.Core && cd AwesomeLibrary.Core && dotnet new classlib
cd ..
mkdir AwesomeLibrary.CSharp && cd AwesomeLibrary.CSharp && dotnet new classlib
cd ..
mkdir AwesomeLibrary.FSharp && cd AwesomeLibrary.FSharp && dotnet new classlib -lang F#
cd ..
dotnet sln add AwesomeLibrary.Core/AwesomeLibrary.Core.csproj
dotnet sln add AwesomeLibrary.CSharp/AwesomeLibrary.CSharp.csproj
dotnet sln add AwesomeLibrary.FSharp/AwesomeLibrary.FSharp.fsproj

```

##### 项目到项目的引用

引用项目的最佳方式是使用 .NET Core CLI 添加项目引用。 在 AwesomeLibrary.CSharp 和 AwesomeLibrary.FSharp 项目目录中，可运行下列命令：

```(bash)
dotnet add reference ../AwesomeLibrary.Core/AwesomeLibrary.Core.csproj
```

AwesomeLibrary.CSharp 和 AwesomeLibrary.FSharp 的项目文件现在需要将 AwesomeLibrary.Core 作为 ProjectReference 目标引用。 可通过检查项目文件和查看其中的下列内容来进行验证：

```xml
<ItemGroup>
  <ProjectReference Include="..\AwesomeLibrary.Core\AwesomeLibrary.Core.csproj" />
</ItemGroup>
```

如果不想使用 .NET Core CLI，可手动将此部分添加到每个项目文件。

##### 结构化解决方案

多项目解决方案的另一个重要方面是建立良好的整体项目结构。 可根据自己的喜好随意组织代码，只要使用 dotnet sln add 将每个项目链接到解决方案文件，就可在解决方案级别运行 dotnet restore 和 dotnet build。

### 如何管理 .NET Core 1.0 的包依赖项版本

下文介绍需要了解的 .NET Core 库和应用的包版本信息。

#### 词汇表

+ **Fix**修复 - 修复依赖项意味着使用 .NET Core 1.0 NuGet 上发布的相同“系列”的包。
+ **Metapackage**元包 - 表示一组 NuGet 包的 NuGet 包。
+ **Trimming**修整 - 从元包删除不依赖的包的操作。 这与 NuGet 包作者有关。 有关详细信息，请参阅减少 [project.json](https://docs.microsoft.com/zh-cn/dotnet/core/deploying/reducing-dependencies) 的包依赖项。

#### 将依赖项修复为 .NET Core 1.0

[若要可靠的回复包并编写可靠代码，将依赖项修复为随.NET Core 1.0一起提供的包版本，这很重要。这意味着每个包应具有单个版本，且没有额外的限定符。](https://docs.microsoft.com/zh-cn/dotnet/core/tutorials/managing-package-dependency-versions)
后续内容略（暂时没看懂）

### 托管.NET COre

像所有的托管代码一样，.NET Core 应用程序也由主机执行。 主机负责启动运行时（包括 JIT 和垃圾回收器等组件）、创建 AppDomain 并调用托管的入口点。
托管 .NET Core 运行时是高级方案，在大多数情况下，.NET Core 开发人员无需担心托管问题，因为 .NET Core 生成过程会提供默认主机来运行 .NET Core 应用程序。 虽然在某些特殊情况下，它对显式托管 .NET Core 运行时非常有用 - 无论是作为一种在本机进程中调用托管代码的方式还是为了获得对运行时工作原理更好的控制。
本文概述了从本机代码启动 .NET Core 运行时、创建初始应用程序域 ([AppDomain](https://docs.microsoft.com/zh-cn/dotnet/api/system.appdomain)) 以及在域中执行托管代码的必要步骤。

#### 系统必备

由于主机是本机应用程序，所以本教程将介绍如何构造 C++ 应用程序以托管 .NET Core。 将需要一个 C++ 开发环境（例如，Visual Studio 提供的环境）。
还将需要一个简单的 .NET Core 应用程序来测试主机，因此应安装 .NET Core SDK 并构建一个小型的 .NET Core 测试应用（例如，“Hello World”应用）。 使用通过新 .NET Core 控制台项目模板创建的“Hello World”应用就足够了。
本教程及其相关示例会构建一个 Windows 主机，请参阅本文结尾处有关在 Unix 上托管的说明。

#### 创建主机

有关展示本文中所述步骤的示例主机，请访问 dotnet/samples GitHub 存储库。 该示例的 host.cpp 文件中的注释清楚地将本教程中已编号的步骤与它们在示例中的执行位置关联。 有关下载说明，请参阅示例和教程。
请记住，示例主机的用途在于提供学习指导，在纠错方面不甚严谨，其重在可读性而非效率。 更多的真实主机示例可从 [dotnet/coreclr](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts) 存储库获取。 尤其是 [CoreRun](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts/corerun) 主机，它是学习者了解简单示例后用来深入学习的通用主机。

##### 有关mscoree.h的说明

.NET Core 主托管接口 (ICLRRuntimeHost2) 在 [MSCOREE.IDL](https://github.com/dotnet/coreclr/blob/master/src/inc/MSCOREE.IDL) 中定义。 主机需要引用的此文件 (mscoree.h) 的标头版本，该版本是在构建 .NET Core 运行时时通过 MIDL 生成。 如果不想构建 .NET Core 运行时，还可在 dotnet/coreclr 存储库中将 mscoree.h 获取为[预生成的标头](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc)。 [有关构建 .NET Core 运行时的说明](https://github.com/dotnet/coreclr#building-the-repository)可在其 GitHub 存储库中找到。

##### 步骤1-标识托管的入口点

引用必要的标头后（例如，mscoree.h 和 stdio.h），.NET Core 主机必须完成的首要任务之一就是找到要使用的托管入口点。 在示例主机中，通过将主机的第一个命令行参数作为托管的二进制文件（将执行该文件的 main 方法）的路径，即可完成此操作。

#### [后续内容略。。。没看懂！！！](https://docs.microsoft.com/zh-cn/dotnet/core/tutorials/netcore-hosting)

### 使用dotnet new创建一个用户模版[没有看完](https://docs.microsoft.com/zh-cn/dotnet/core/tutorials/create-custom-template)

此处将简述一下内容：

+ 使用已有程序或者控制台方法建立一个基本模版

+ 从nuget.org或者本地nupkg打包以供分发

+ 从 nuget.org nupkg 或则本地文件系统安装模版

+ 卸载模版

示例模版代码[连接地址](https://github.com/dotnet/dotnet-template-samples/tree/master/16-nuget-package)
该示例是按照NuGet发布风格配置的。

如果需要使用示例的文件系统进行操作还需要进行以下工作：

1. 把*contents*文件下的文件移动到*GarciaSoftware.ConsoleTemplate.CSharp*下

2. 删除空的*contents*文件

3. 删除*nuspec*文件

#### 从一个文件创建模版

从本地硬盘中已有的文件中创建一个模版，一般文件模版的文件名为:公司.模版类型.使用语言。然后进行如下操作：

1. 在文件根目录下添加名为 *.template.config* 的目录

2. 在 *.template.config* 目录下添加配置文件 *template.json*。 如需了解json文件 更多内容请参阅[新用户控制台程序模版定义](https://docs.microsoft.com/zh-cn/dotnet/core/tools/custom-templates#templatejson)

###
-----------

## ASP.NET

> + [极客学院 ASP.NET 教程](http://wiki.jikexueyuan.com/project/asp-net/environment-setup.html)
> + [ASP.NET 学习总结（50+篇）](http://www.shouce.ren/api/view/a/15487)
> + [.NET Core+MySql+Nginx 容器化部署](https://www.jianshu.com/p/2a755277a1e6)
> + [Asp.net mvc 知多少（一）](https://www.jianshu.com/p/5f6156cacc76)

### ASP.Net 简介

**Active Server Pagese**（ASP，活动服务器页面）
ASP.NET 是一个 web 开发平台，它提供编程模型、软件基础程序以及多种服务来帮助开发者搭建健壮的网络应用程序。

ASP.NET 工作于 HTTP 协议之上，并使用 HTTP 命令和政策来建立浏览器到用户之间双向的交流与合作。

ASP.NET 是 Microsoft.NET 平台的一部分。ASP.NET 应用程序是编译后的代码，运行在 .Net framework 中，利用可扩展和可重用的组件和对象编写的。

ASP.NET 应用程序编码可以用以下语言编写：

+ C#
+ Visual Basic.Net
+ Jscript
+ J#

#### ASP.NET Web 表单模型

ASP.NET web 表单延伸了交互作用对 web 应用程序的事件驱动模型。浏览器提交给 web 服务器一个 web 表单，然后服务器返回一个完整的标记页面或 HTML 页面作为回应。

所有客户端用户活动转发到服务器进行有状态的处理。服务器处理客户端动作的输出并触发反馈。

现在，HTTP 是一种无状态协议。ASP.NET 框架帮助储存有关应用程序状态的信息，由以下组成：

+ 页状态
+ 会话状态

页状态是客户端状态，例如：在 web 表单中不同输入领域的内容。会话状态是由用户浏览和使用的不同页面中获得的集合信息。

#### 项目和解决方案

一个典型的 ASP.NET 应用程序由许多的项目组成：web 内容文件（.aspx），源文件（.cs 文件），程序集（.dll 和 .exe 文件），数据源文件（.mgd 文件），引用，图标，用户控件和其他杂项文件和文件夹。所有组成网址的这些文件包含在一个解决方案中。

当创造了一个新的网站，.visual studio 自动创造了解决方案，并且在解决方案管理器中显示。

解决方案可能包含一个或多个项目。一个项目包含内容文件，源文件，以及其他文件比如说数据源和图片文件。一般来说，一个项目的内容可以编译成一个程序集作为一个可执行文件（.exe）或者一个动态链接库（.dll）文件

一般来说一个项目包含以下内容文件：

+ 页面文件（.aspx）
+ 用户控件（.ascx）
+ Web 服务器（.asmx）
+ 主版页（.master）
+ 网站导航（.sitemap）
+ 网站配置文件（.config）

### 生命周期

ASP.NET 生命周期指定如何：

+ ASP.NET 处理页面生成动态输出
+ 应用程序及其页面进行实例化和处理
+ ASP.NET 动态编译页面

ASP.NET 生命周期可以被分为两组：

+ 应用程序生命周期
+ 页面生命周期

#### ASP.NET 应用程序生命周期

应用程序生命周期有以下阶段：

+ 用户请求访问应用程序的资源，即一个页面。浏览器发送此请求到 web 服务器。
+ 一个统一管道接收第一个请求，并发生以下事件：

  + 一个 ApplicationManager 类的对象创建。

  + 一个 HostingEnvironment 类的对象创建从而提供信息资源。
  
+ 创建响应对象。应用程序对象如 HttpContext，HttpRequest 和 HttpResponse 被创建并初始化。
+ 一个 HttpApplication 对象的实例被创建并被分配到请求。
+ 请求由 HttpApplication 类所处理。不同的事件引发此类处理请求。

#### ASP.NET 页面生命周期

当请求一个页面时，页面被加载到服务器内存，然后处理并送达到浏览器中。然后再从内存中卸载。在这些步骤中的每一步，方法和事件都是可用的，可以根据应用程序所需进行改写。换言之，你可以编写自己的代码从而去置换缺省代码。

页面类创建了页面上所有控件的等级树。页面上所有的组件，除了指令，其余都是控件树的一部分。你可以通过在页面指令上添加 trace = "true" 来看到控制树。我们会覆盖页面指令，然后在 'directives' 和 'event handling' 下追踪。

页面生命周期阶段为：

+ 初始化
+ 页面控件实例化
+ 状态恢复和维护
+ 事件处理代码的执行
+ 页面显示

以下是一个ASP.NET页面的不同阶段：

+ **页面请求** - 当 ASP.NET 得到一个页面请求，它决定是否解析和编译页面，或者会有一个页面的缓存版本；相应地进行回应。
+ **页面生命周期的开启** - 在这个阶段，设置请求和回应对象。如果是一个旧的请求或者是回发+ 的，页面 IsPostBack 属性设置为正确。页面 ULCulture 属性同样也被设置。
+ **页面初始化** - 在此阶段，页面上的控件通过设置 UniqueID 属性被分配到独特的 ID 并应用主题。对于一个新的请求，加载回发数据并且控件属性被重新储存到视图状态下的值。
+ **页面加载** - 在此阶段，设置控件属性，使用视图状态和控件状态值。
+ **验证** - 调用验证控件的校验方法并成功执行，页面的 IsValid 属性设置为 true。
+ **回发事件处理** - 如果请求是一个回发（旧请求），相关事件处理程序被调用。
+ **页面显示** - 在此阶段，页面的视图状态和所有控件被保存。页面为每一个控件调用显示方法，并且呈现的输出被写入页面响应属性中的 OutputStream 类。
+ **卸载** - 显示过的页面被送达客户端以及页面属性，例如响应和请求，被卸载并全部清除完毕。

#### ASP.NET 页面生命周期事件

在页面生命周期的每一阶段，页面引发一些时间，会被编码。一个事件处理程序基本上是一个函数或子程序，绑定到事件，使用声明式如 OnClick 属性或处理。

以下是页面生命周期事件：

+ PreInit - PreInit 是页面生命周期的第一个事件。它检查 IsPostBack 属性并决定页面是否是回发。它设置主题及主版页，创建动态控件，并且获取和设置值配置文件属性值。此事件可通过重载 OnPreInit 方法或者创建一个 Page_PreInit 处理程序进行处置。
+ Init - Init 事件初始化控件属性，并且建立控件树。此事件可通过重载 OnInit 方法或者创建一个 Page_Init处理程序进行处置。
+ InitComplete - InitComplete 事件允许对视图状态的跟踪。所有的控件开启视图状态下的跟踪。
+ LoadViewState - LoadViewState 事件允许加载视图状态信息到控件中。
+ LoadPostData - 在此阶段期间，对所有由 \ 标签定义的输入字段的内容进行处理。
+ PreLoad - PreLoad 在回发数据加载在控件中之前发生。此事件可以通过重载 OnPreLoad 方法或者创建一个 Pre_Load 处理程序进行处置。
+ Load - Load 事件被页面最先引发，然后递归地引发所有子控件。控件树中的控件就被创建好了。此事件可通过重载 OnLoad 方法或者创建一个 Page_Load 处理程序来进行处置。
+ LoadComplete - 加载进程完成，控件事件处理程序运行，页面验证发生。此事件可通过重载 OnLoad 方法或者创建一个 Page_LoadComplete 处理程序来进行处置。
+ PreRender - PreRender 事件就在输出显示之前发生。通过处理此事件，页面和控件可以在输出显示之前执行任何更新。
+ PreRenderComplete - 当 PreRender 事件为所有子控件被循环引发，此事件确保了显示前阶段的完成。
+ SaveStateComplete - 页面控件状态被保存。个性化、控件状态以及视图状态信息被保存。
+ UnLoad - UnLoad 阶段是页面生命周期的最后一个阶段。它为所有控件循环引发 UnLoad 事件，最后为页面自身引发。最终完成清理和释放所有资源和引用，比如数据库连接。此事件可通过调整 OnLoad 方法或者创建一个 Page_UnLoad 处理程序来进行处置。

### 实例

ASP.NET 页面是由大量的服务器控件以及 HTML 控件、文本和图像组成的。页面的敏感数据和页面上的不同控件状态被储存在隐藏字段中，组成了页面请求的配置指令。

ASP.NET 运行时控制一个页面实例和其状态的关联。一个 ASP.NET 页面是一个页面的对象或者从之继承而来。

页面上所有的控件同样也是从一个父类控件继承而来的相关控件类的对象。当一个页面运行时，对象页面的一个实例就随其内容控件一起被创建。

一个 ASP.NET 页面同样也是储存在 .aspx 延伸的服务器端文件。

它在本质上是模块化的，并且可被分成以下几个核心部分：

+ 网页指令
+ 编码区段
+ 页面布局

### 事件处理

ASP.NET 上的事件在用户机器上引发，在服务器上处理。例如，一个用户点击了在浏览器中显示的一个按钮。一个点击事件被引发。浏览器通过把它发送给服务器从而处理这个客户端事件。

服务器有一个子程序来描述当事件被引发时该做什么；这个被称为**事件处理程序**。因此，当事件信息被传递给服务器，它会检查点击事件是否与事件处理程序有关联。如果有关联的话，事件处理程序就会被执行

#### 事件参数

ASP.NET 事件处理程序一般采用两个参数并返回空。第一个参数代表了对象激发事件，第二个参数是事件参数。

一个事件的一般句法是：

> private void EventName (object sender, EventArgs e);

private 或 protected

#### 应用程序和会话事件

最重要的应用程序事件是：

+ Application_Start - 当开启应用程序或者网页时被引发。
+ Application_End - 当停止应用程序或者网页时被引发。

同样的，最常使用的会话事件是：

+ Session_Start – 当用户最开始从应用程序上请求一个页面被引发。
+ Session_End – 当会话结束后被引发。

#### 页面和控件事件

+ DataBinding – 当一个控件绑定到一个数据源时被引发。
+ Disposed – 当释放页面或者控件时被引发。
+ Error – 它是一个页面事件，当有未处理的异常时发生。
+ Init – 当初始化页面或者控件时被引发。
+ Load – 当加载页面或者控件时被引发。
+ PreRender – 当显示页面或者控件时被引发。
+ Unload – 当从内存中卸载页面或者控件时被引发。

#### 使用页面控件处理事件

常见的控件事件有：
| 事件 | 属性 | 控件 |
| ------ | ------ | ------ |
| Click | OnClick | 按钮，图像按钮，链接按钮，图像导位图 |
| Command | OnCommand | 按钮，图像按钮，链接按钮 |
| TextChanged | OnTextChanged | 文本框 |
| SelectedIndexChanged | OnSelectedIndexChanged | 下拉菜单，列表框，单选按钮列表，带复选框的列表框 |
| CheckedChanged | OnCheckedChanged | 复选框，单选按钮 |

一些事件导致表单立即发回到服务器，这些被称为回调事件。例如，单击事件像 Button.Click。

一些事件则不会被立即发回到服务器，这些被称为非回调事件。

例如，改变事件或者选择事件，像 TextBox.TextChanged 或者 CheckBox.CheckedChanged。这些非回调事件可以通过设置它们的 AutoPostBack 属性为 true 便可立即使它们回调。

#### 默认事件

页面对象的默认事件是加载事件。相似地，每一个控件都有一个默认的事件。比如，按钮控件的默认事件就是 Click 事件。

默认事件处理程序可以在 Visual Studio 中创建，仅通过双击设计视图中的控件。以下表格展示了一写常见控件的默认事件：

 控件 | 默认事件
-----|----------
广告控件（AdRotator）| AdCreated
项目列表（BulletedList）| Click
按钮（Button）| Click
日历控件（Calender） | SelectionChanged
复选框（CheckBox）| CheckedChanged
复选列表（CheckBoxList)| SelectedIndexChanged
数据表格（DataGrid）| SelectedIndexChanged
数据列表（DataList）| SelectedIndexChanged
下拉列表（DropDownList） | SelectedIndexChanged
超链接（HyperLink） | Click
图像按钮（ImageButton） | Click
热点（ImageMap） | Click
超链接按钮（LinkButton） | Click
单选或多选的下拉列表（ListBox ） | SelectedIndexChanged
菜单（Menu） | MenuItemClick
单选按钮（RadioButton） | CheckedChanged
单选按钮组（RadioButtonList） | SelectedIndexChanged

### 服务器端

我们已经研究了页面生命周期和一个页面如何包含不同的控件。页面本身作为一个控制对象被实例化。所有的 web 表单基本上是 ASP.NET 页面类的实例。页面类有以下极其有用的属性，与内部对象所对应：

+ 会话
+ 应用程序
+ 缓存
+ 请求  **Request**
+ 响应 **Response**
+ 服务器 **Server**
+ 用户
+ 跟踪

我们会在适当的时间里讨论每一个对象。在本教程中我们将会探索 Server 对象，Request 对象和 Response 对象。

#### Server 对象

ASP.NET 中的服务器对象是 **System.Web.HttpServerUtility** 类的一个实例。The HttpServerUtility 类提供了大量的属性和方法来执行不同的工作

#### Sever 对象和方法

HttpServerUtility类的方法和属性通过ASP.NET提供的内部服务器对象公开的。
以下表格提供了HttpServerUtility类一系列的属性：

 属性 | 描述
---- | ----
MachineName | 服务器电脑的名称
ScriptTimeOut | 以秒为单位获取和设置请求超时的值

以下表格提供了一些重要的方法:
方法 | 描述
---- | ----
CreateObject(String) | 创建一个 COM 对象的实例，由其 ProgID 验证。
CreateObject(Type) | 创建一个 COM 对象的实例，由其 Type 验证。
Equals(Object) | 决定具体的对象是否和现有对象一致。
Execute(String) | 在当前请求的上下文中执行处理应用程序指定的虚拟路径。
Execute(String, Boolean) | 在当前请求的上下文中执行处理程序指定的虚拟路径，指定是否清除 QueryString及表单集合。
GetLastError | 返回之前的异常。
GetType | 获取现有实例的类型。
HtmlEncode | 将一个普通的字符串变成合法的 HTML 字符串。
HtmlDecode | 将一个 Html 字符串转化成一个普通的字符串。
ToString | 返回一个表示当前对象的字符串。
Transfer(String) | 对于当前请求，终止当前页面的执行并通过指定页面的 URL 路径，开始执行一个新页面。
UrlDecode | 将一个 URL 字符串转化成一个普通的字符串。
UrlEncodeToken | 与 UrlEncode 作用相同，但是在一个字节数组中，包含以 Base64 编码的数据。
UrlDecodeToken | 与 UrlDecode 工作相同，但是在一个字节数组中，包含以 Base64 编码的数据。
MapPath | 返回与指定的虚拟服务器上的文件路径相对应的物理路径。
Transfer | 在当前应用程序上转移执行到另一个 web 页面。

#### Request 对象

请求对象是 **System.Web.HttpRequest** 类的一个实例。它代表了 HTTP 请求的值和属性，使页面加载到浏览器中。

此对象所呈现的信息被封装在更高级别的抽象中（web 控件模型）。然而，这个对象可以帮助检查一些信息，例如客户端浏览器和信息记录程序。

#### Request 对象的属性和方法

下表提供了请求对象一些值得注意的属性：

属性 | 描述
--- | ---
AcceptTypes | 获取一个用户支持的 MIME 接受类型的字符串数组。
ApplicationPath | 在服务器上获取 ASP.NET 应用程序的真实应用程序根路径。
Browser | 获取或设置关于请求用户浏览器能力的信息。
ContentEncoding | 获取或设置字符集的实体。
ContentLength | 指定由客户端发送的内容的长度以字节为单位。
ContentType | 获取或设置传入请求的 MIME 内容类型。
Cookies | 获取客户端发送的 cookies 集合。
FilePath | 获取当前请求的真实路径。
Files | 以多部分的 MIME 格式获取客户端上传文件的集合。
Form | 获取表单变量的集合。
Headers | 获取 HTTP 标题的集合。
HttpMethod | 获取用户使用的 HTTP 数据转移方法（如 GET，POST，或者 HEAD）
InputStream | 获取传入的 HTTP 的实体内容。
IsSecureConnection | 获取一个值，该值指示 HTTP 连接是否使用安全套接字（即HTTPS）。
QueryString | 获取 HTTP 询问字符串变量的集合。
RawUrl | 获取当前请求的原始 URL。
RequestType | 获取或设置由用户使用的 HTTP 数据转移方法（GET 或者 POST）。
ServerVariables | 获取 Web 服务器变量的集合。
TotalBytes | 获取现有输入流的字节数。
Url | 获取关于现有请求的 URL 的信息。
UrlReferrer | 获取关于与现有 URL 相链接的客户端之前的请求的 URL 信息。
UserAgent | 获取客户端浏览器的原始用户代理字符串。
UserHostAddress | 获取远程客户机的 IP 主机地址。
UserHostName | 获取远程客户机的 DNS 名称。
UserLanguages | 获取客户端语言首选项的排序字符串数组。

下表提供了请求对象一些重要的方法：
方法 | 描述
---- | ----
BinaryRead | 从当前的输入流中执行一个指定字节数的二进制读数。
Equals(Object) | 决定指定对象是否等同于现有对象。（继承自对象）
GetType | 获取现有实例的类型。
MapImageCoordinates | 将传入的象场表单参数绘制成适当的 x 坐标和 y 坐标值。
MapPath(String) | 将指定的真实路径绘制成一个物理路径。
SaveAs | 在硬盘中存为一个 HTTP 请求。
ToString | 返回一个代表现有对象的字符串。
ValidateInput | 导致验证发生，通过访问 Cookies，Form，QueryString 属性的集合。

#### Response 对象

响应对象代表了服务器对于用户请求的响应。它是 **System.Web.HttpResponse** 类的一个实例。

在 ASP.NET 中，响应对象在给用户发送 HTML 文本的过程中不扮演任何重要的角色，因为服务器端控件有嵌套的、面向对象的方法来自我呈现。

然而，HttpResponse 对象提供了一些重要的功能，比如 cookie 特点和 Redirect() 方法。 Response.Redirect() 方法允许将用户转移到另一个页面，在应用程序内部或应用程序外部均可。它需要一个往返过程。

#### Response 对象的属性和方法

下表提供了一些响应对象值得注意的属性：

属性 | 描述
---- | ----
Buffer | 获取或设置一个值，表明是否缓冲输出，并在完整的响应程序结束后将其发送。
BufferOutput | 获取或设置一个值，表名是否缓冲输出，并在完整页面结束进城后将其发送。
Charset | 获取或设置输出流的 HTTP 字符集。
ContentEncoding | 获取或设置输出流的 HTTP 字符集。
ContentType | 获取或设置输出流的 HTTP MIME 类型。
Cookies | 获取相应 cookie 集合。
Expires | 获取或设置一个浏览器上缓存的页面在到期前的分钟数。
ExpiresAbsolute | 获取或设置从缓存中移除缓存信息的绝对日期和时间。
HeaderEncoding | 获取或设置一个编码对象，代表现有标题输出流的编码。
Headers | 获取响应标题的集合。
IsClientConnected | 获取一个值，表明用户是否仍和服务器相连。
Output | 使输出的文本到输出的 HTTP 响应流。
OutputStream | 使二进制输出到输出的 HTTP 内容本体。
RedirectLocation | 获取或设置 Http 标题位置的值。
Status | 设置状态栏，返回给客户端。
StatusCode | 获取或设置返回到客户端的 HTTP 输出状态码。
StatusDescription | 获取或设置返回给客户端的 HTTP 输出状态字符串。
SubStatusCode | 获取或设置一个值限制响应的状态码。
SuppressContent | 获取或设置一个值，表明是否发送 HTTP 内容到客户端。

下表提供了一些重要的方法：

方法 | 描述
---- | ----
AddHeader | 给输出流添加一个 HTTP 标题。提供 AddHeader 是为了 ASP 早期版本的兼容性。
AppendCookie | 基础设施为内部 cookie 集合添加一个 HTTP cookie。
AppendHeader | 给输出流添加一个 HTTP 标题。
AppendToLog | 将自定义日志信息添加到 InterNET 信息服务（IIS）日志文件。
BinaryWrite | 将一串二进制字符写入 HTTP 输出流。
ClearContent | 清除缓冲流中的所有内容输出。
Close | 关闭客户端套接字。
End | 发送所有现有的缓冲输出给客户端，停止页面执行，并且引发 EndRequest 事件。
Equals(Object) | 确定指定对象是否等同于现有对象。
Flush | 发送所有现有缓冲输出到客户端。
GetType | 获取现有实例的类型。
Pics | 将一个 HTTP PICS-Label 标题附加到输出流。
Redirect(String) | 将请求重定向到一个新的 URL 并指定新的 URL。
Redirect(String, Boolean) | 将客户端重定向到一个新的 URL。指定新的 URL 并且之指定现有页面是否应该终止。
SetCookie | 在 cookie 集合中更新现存 cookie。
ToString | 返回代表现有对象的一个字符串
TransmitFile(String) | 直接编写指定的文件到一个 HTTP 响应输出流中，不需要在内存中缓冲。
Write(Char) | 编写一个字符到一个 HTTP 响应输出流中。
Write(Object) | 编写一个对象到一个 HTTP 响应流中。
Write(String) | 编写一个字符串到一个 HTTP 响应输出流中。
WriteFile(String) | 直接编写指定文件的内容到一个 HTTP 响应输出流中，作为一个文件块。
WriteFile(String, Boolean) | 直接编写指定文件的内容到一个 HTTP 响应输出流中，作为一个内存块。

### 服务器控件

控件是在图形用户界面中的小功能块，其中包括文本框，按钮，复选框，列表框，标签，和许多其它工具。利用这些工具，用户可以输入数据，进行选择并注明自己的喜好。

控件也用于结构性工作，如验证，数据访问，安全保证，创建母版页和数据操作。

ASP.NET 使用五种类型的 Web 控件，它们是：

+ HTML 控件
+ HTML 服务器控件
+ ASP.NET 服务器控件
+ ASP.NET Ajax 服务器控件
+ 用户控件和自定义控件

ASP.NET 服务器控件是在 ASP.NET 中使用的主要控件。这些控件可被分成以下几类：

+ 验证控件 - 用来验证用户输入，并通过运行客户端脚本进行工作。
+ 数据源控件 - 提供数据绑定到不同的数据源功能。
+ 数据视图控件 - 该控件为各种列表和表格，可以显示从数据源绑定的数据。
+ 个性化控件 - 根据用户的喜好，基于用户信息进行页面个性化设置。
+ 登陆和安全控件 - 提供用户身份验证。
+ 母版页 - 提供整个应用程序一致的布局和界面。
+ 导航控件 - 帮助用户导航。例如，菜单，树视图等。
+ 丰富功能控件 - 实施特殊功能。例如：AdRotator, FileUpload, 和日历控件。

使用服务器控件的基本语法是：
><asp:controlType  ID ="ControlID" runat="server" Property1=value1  [Property2=value2] />

此外，Visual Studio还具有以下特点，以帮助产生无差错代码：

+ 在设计视图中拖动和丢弃控件。
+ 显示及自动完成特性的智能感知功能。
+ 直接设置属性值的属性窗口。

#### 服务器控件的属性

具有可视化功能的 ASP.NET 服务器控件来源于 WebControl 类，并且继承该类别的所有属性，事件以及方法。

WebControl 类本身以及其他不具有可视化功能的服务器控件都来源于 System.Web.UI.Control 类。例如，PlaceHolder 控件或 XML 控件。

ASP.Net 服务器控件继承了 WebControl 和 System.Web.UI.Control 类的所有属性，事件，以及方法。

下表显示了通用于所有服务器控件的属性：

属性 | 描述
---- | ----
AccessKey | 同时按下该按键以及 Alt 键以将焦点移至控件。
Attributes | 它是不对应控件属性的任意属性（仅用于视图呈现）的集合。
BackColor | 背景色。
BindingContainer | 包含数据绑定的控件。
BorderColor | 边框颜色。
BorderStyle | 边框样式。
BorderWidth | 边框宽度。
CausesValidation | 引起验证时显示。
ChildControlCreated | 表示服务器控件的子控件是否建立。
ClientID | HTML 标记的控件 ID。
Context | 与服务器控件关联的 HttpContext 对象。
Controls | 控件内全部控件的集合。
ControlStyle | Web 服务器控件的样式。
CssClass | CSS 类。
DataItemContainer | 若命名器执行 IDataItemContainer，则为命名器提供参考。
DataKeysContainer | 若命名器执行 IDataKeysControl，则为命名器提供参考。
DesignMode | 表示控件在设计界面是否被使用。
DisabledCssClass | 当控件禁用时，获取或设置 CSS 类来应用呈现的 HTML 元素。
Enabled | 表示控件是否被禁用。
EnableTheming | 表示主题是否适用于控件。
EnableViewState | 表示是否维持控件的视图状态。
Events | 获取代表控件的事件处理程序的列表。
Font | 字体设定。
Forecolor | 前景颜色。
HasAttributes | 表示控件是否具有属性组。
HasChildViewState | 表示当前服务器控件的子控件是否具有任何已保存的视图状态设置。
Height | 高度的像素或百分比。
ID | 控件的标识符。
IsChildControlStateCleared | 表示包含在该控件内部的控件是否具有控件状态。
IsEnabled | 获取表示控件是否被启用的值。
IsTrackingViewState | 表示服务器控件是否会将更改保存到其视图状态。
IsViewStateEnabled | 表示视图状态是否对该控件启用。
LoadViewStateById | 表示控件是否是由 ID 而非索引来参与加载其视图状态。
Page | 包含控件的页面。
Parent | 家长控制功能。
RenderingCompatibility | 指定呈现的 HTML 将与之兼容的 ASP.NET 版本。
Site | 当设计界面显示时容纳当前控件的承载器。
SkinID | 获取或设置适用于控件的皮肤。
Style | 获取将在 Web 服务器控件的外部标签作为样式属性显示的文本属性的集合。
TabIndex | 获取或设置 Web 服务器控件的索引标签。
TagKey | 获取对应该 Web 服务器控件的 HtmlTextWriterTag 值。
TagName | 获取控件标签的名称。
TemplateControl | 包含该控件的模板。
TemplateSourceDirectory | 获取页面的虚拟目录或包含在该控件中的控件。
ToolTip | 获取或设置当鼠标指针停在 Web 服务器控件时显示的文本。
UniqueID | 唯一的标识符。
ViewState | 获取能够穿越同一页面的多重请求后保存和恢复服务器控件视图状态的状态信息词典。
ViewStateIgnoreCase | 表示 StateBag 对象是否不区分大小写。
ViewStateMode | 获取或设置该控件的视图状态。
Visible | 表示服务器控件是否可见。
Width | 获取或设置 Web 服务器控件的宽度。

#### 服务器控件的方法

方法 | 描述
--- | ---
AddAttributesToRender | 添加需要呈现指定 HtmlTextWriterTag 的 HTML 属性和样式。
AddedControl | 在子控件添加到控件对象的控件集合后调用。
AddParsedSubObject | 通报服务器控件一个元素，XML 或 HTML 已被解析，并将该元素添加到服务器控件的控件集合。
ApplyStyleSheetSkin | 将在页面样式表中定义的样式属性应用到控件中。
ClearCachedClientID | 基础设施。设置缓存的 ClientID 值设置为 null。
ClearChildControlState | 为服务器控件的子控件删除控件状态信息。
ClearChildState | 为所有服务器控件的子控件删除视图状态和控件状态信息。
ClearChildViewState | 为所有服务器控件的子控件删除视图状态信息。
CreateChildControls | 用于创建子控件。
CreateControlCollection | 创建一个用于保存子控件的新控件集合。
CreateControlStyle | 创建一个用于实现所有与样式有关的属性的样式对象。
DataBind | 将数据源绑定到服务器控件及其所有子控件。
DataBind(Boolean) | 将数据源及可以引发 DataBinding 事件的选项绑定到服务器控件及其所有子控件。
DataBindChildren | 将数据源绑定到服务器控件的子控件。
Dispose | 启用一个服务器控件在其从内存中释放出来前去执行最后的清理操作。
EnsureChildControls | 确定服务器控件是否包含子控件。若没有，则创建子控件。
EnsureID | 为没有标识符的控件创建一个标识符。
Equals(Object) | 确定指定对象是否等于当前对象。
Finalize | 允许一个对象去尝试释放资源并在对象被回收站回收前执行其他清理操作。
FindControl(String) | 搜索当前命名容器中具有指定 id 参数的服务器控件。
FindControl(String, Int32) | 搜索当前命名容器中具有指定 id 参数和整数的服务器控件。
Focus | 为控件设置输入焦点。
GetDesignModeState | 获取控件的设计时数据。
GetType | 获取当前实例的类型。
GetUniqueIDRelativeTo | 返回指定控件的唯一 ID 属性的预固定部分。
HasControls | 确定服务器控件是否包含子控件。
HasEvents | 表示事件是否被控件或其他子控件注册。
IsLiteralContent | 确定服务器控件是否仅含有文字内容。
LoadControlState | 恢复控件状态信息。
LoadViewState | 恢复视图状态信息。
MapPathSecure | 检索绝对的或相对的虚拟路径映射到的物理路径。
MemberwiseClone | 创建当前对象的浅复制。
MergeStyle | 复制指定样式的 Web 控件的任意非空白元素，但不覆盖该控件现有的任何样式元素。
OnBubbleEvent | 确定服务器控件的事件是否通过页面的 UI 服务器控件层级。
OnDataBinding | 引发数据绑定事件。
OnInit | 引发 Init 事件。
OnLoad | 引发加载事件。
OnPreRender | 引发 PreRender 事件。
OnUnload | 引发卸载事件。
OpenFile | 获取用于读取文件的流。
RemovedControl | 在子控件从控件对象的控件集合中移除后调用。
Render | 显示控件到指定的 HTML 作者。
RenderBeginTag | 显示控件的 HTML 开口标签到指定作者。
RenderChildren | 输出服务器控件子级的内容到提供的 HtmlTextWriter 对象中，从而编写呈现在客户端上的内容。
RenderContents | 显示控件内容到指定作者。
RenderControl(HtmlTextWriter) | 输出服务器控件内容到提供的 HtmlTextWriter 对象并在启用跟踪的情况下保存关于控件的跟踪信息。
RenderEndTag | 显示控件的 HTML 结束标签到指定作者。
ResolveAdapter | 获取负责呈现指定控件的控件适配器。
SaveControlState | 保存自页面回发到服务器后出现的服务器控件的状态改变。
SaveViewState | 保存调用 TrackViewState 方法之后修改的任意状态。
SetDesignModeState | 为控件设置设计时数据。
ToString | 返回代表当前对象的字符串。
TrackViewState | 引发控件跟踪其视图状态的变化，使其可以存储在该对象的视图状态属性中。

### HTML 服务器

HTML 服务器控件主要是保证服务端运行的增强型标准 HTML 控件。HTML 控件不是由服务器处理，而是被发送到浏览器进行显示，比如页面标题标签，链接标签及输入元素。

通过添加 runat = "server" 属性和一个 id 属性，它们可被特定地转化为一个服务器控件，应用于服务器端处理。

例如，HTML 输入控件：

```html
 <input type="text" size="40">
```

它可以通过添加 runat 和 id 属性被转换成一个服务器控件：

```html
 <input type="text" id="testtext" size="40" runat="server">
```

#### 使用HTML服务器控件的优点

尽管 ASP.NET 服务器控件可以完成 HTML 服务器控件执行的每一项工作，HTML 控件在以下情况仍然具有优势：

+ 使用静态表达到布局目的。
+ 转换一个 HTML 页面到 ASP.NET 下运行

下面这个表格介绍了 HTML 服务器控件：

控件名称 | HTML 标签
------- | ---------
HtmlHead | \<head>element
HtmlInputButton | \<input type=button|submit|reset>
HtmlInputCheckbox | \<input type=checkbox>
HtmlInputFile | \<input type = file>
HtmlInputHidden | \<input type = hidden>
HtmlInputImage | \<input type = image>
HtmlInputPassword | \<input type = password>
HtmlInputRadioButton | \<input type = radio>
HtmlInputReset | \<input type = reset>
HtmlText | \<input type = text|password>
HtmlImage | \<img> element
HtmlLink | \<link> element
HtmlAnchor | \<a> element
HtmlButton | \<button> element
HtmlButton | \<button> element
HtmlForm | \<form> element
HtmlTable | \<table> element
HtmlTableCell | \<td> and \<th>
HtmlTableRow | \<tr> element
HtmlTitle | \<title> element
HtmlSelect | \<select>  element
HtmlGenericControl | 未列出的所有 HTML 控件

### 客户端

ASP.NET 的客户端编码有两方面：

+ **客户端脚本**：它在浏览器中运行并且依次加速页面的执行。例如，客户端数据有效性能够捕捉无效数据并相应地提醒用户而不经过在服务器中回发。
+ **客户端源代码**：ASP.NET 网页形成了该客户端源代码。例如，ASP.NET 网页的 HTML 源代码包含了若干隐藏区域并能自动注入 Java 描述语言代码，从而保留了信息像视图状态一样，或者进行其他工作保证网页正常运作。

#### 客户端脚本

所有 ASP.NET 服务器控件都允许响应通过 Java 语言或者 VBS 语言绘制的编码。有些 ASP.NET 服务器控件端使用客户端脚本进行对用户需求的反应，而并没有回发到服务器。例如，数据有效性控件。

除了这些脚本，按钮控件具有恰当的 OnClientClick 方法，能够在按钮单击时执行客户端脚本。

传统服务器 HTML 控件有以下几个事件能够在脚本发起时执行脚本：

事件 | 属性
---- | ----
onblur | 当控件失去焦点时触发
onfocus | 当控件获得焦点触发
onclick | 当控件被单击时触发
onchange | 当控件值发生改变时触发
onkeydown | 当用户按下键盘按钮时触发
onkeypress | 当用户按下字母数字的按键时
onkeyup | 当用户释放按键时触发
onmouseover | 当用户移动鼠标指针在控件界面时触发
onserverclick | 当控件界面被单击时，启动 ServerClick 事件控件

#### 客户端源代码

我们已经在以上内容中讨论过了客户端源代码。ASP.NET 网页通常被编写在两种文件中：

+ 内容文件或者审定文件(.aspx)
+ 代码后置的文件

内容文件包含 HTML 或者 ASP.NET 控件标签和文字来形成页面结构。代码后置的文件包含了分类定义。在运行时间，内容文件被解析并被传送到一个页面类。

这个页面类以及在编码文件中的类的定义和系统生成的编码共同组成执行编码（集成），这些集成编码加工所有的回发数据，产生响应和发回客户动作。

### 基础控件

#### 按钮控件

ASP.NET 提供了三种不同类型的按钮控件：

+ 按钮：在矩形区域内显示文本。
+ 链接按钮：像超链接一样显示文本。
+ 图像按钮：显示图像。

当用户单击一个按钮时，两个事件被触发：单击和指令。

按钮控件的基础语法：

```html
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Click" / >
```

按钮控件的通用属性：

属性 | 描述
---- | ----
Text | 文本显示在按钮上。仅对于按钮和链环按钮的控件。
ImageUrl | 仅对于图像按钮控件。这个图像是为了显示按钮。
AlternateText | 仅对于图像按钮控件。如果浏览器无法显示图像，替换文本会显示。
CausesValidation | 当用户单击按钮时确定是否执行页面验证。默认为真。
CommandName | 当用户单击按钮时传递给命令事件的字符串值。
CommandArgument | 当用户单击按钮时传递给命令事件的字符串值。
PostBackUrl | 当用户单击按钮时出现需要的页面地址。

#### 文本框和标签

文本框控件是专门接受用户输入而设置。一个文本框控件可以依据文本模式的属性接受一条或多条文本的输入。

标签控件为显示文本提供了一个简单的方法，这种方法能够从执行一个页面到下一个页面。如果想要显示一个不变的文本，那么您可以使用文字文本。

正文控制的基本语法：

```html
<asp:TextBox ID="txtstate" runat="server" ></asp:TextBox>
```

文本框和标签的通用属性：

属性 | 描述
---- | ----
TextMode | 指定文本框类型。单行模式创建标准文本，多行模式创建能够接受多个文本，口令会引发输入待标记的字符。默认为标准文本。
Text | 文本框的文本内容。
MaxLength | 输入文本框中文本字符的最大值。
Wrap | 它确定多行文本框中文本是否自动换行的;默认值是真。
ReadOnly | 确定用户是否可以更改框中的文本;默认为假，即用户可以更改文本。
Columns | 在字符的文本框的宽度。实际宽度是基于用于文本输入的字体来确定。
Rows | 多行文本框的高度。默认值是 0，表示一个单行文本框。
大多使用属性的标签控件是 'Text'，它代表在标签上显示的文本。

大多使用属性的标签控件是 'Text'，它代表在标签上显示的文本

#### 复选框和单选按钮

一个复选框将显示一个选项，用户可以选中或取消。单选按钮呈现一组用户可以只选择一个选项的选项组。

如果要创建一组单选按钮，您可以为每个单选按钮组中的组名属性指定相同的名称。如果一个以上的组需要呈现一个单一的形式，则指定每个组不同的组的名称。

如果您想按照最初显示的形式来选中复选框或单选按钮，可将其选中属性为 true。如果多个单选按钮在一组的属性设置为 true，则只有最后一个被认为是 true

复选框的基本语法：

```html
<asp:CheckBox ID= "chkoption" runat= "Server">
</asp:CheckBox>
```

单选按钮的基本语法：

```html
<asp:RadioButton ID= "rdboption" runat= "Server">
</asp: RadioButton>
```

复选框和单选按钮的通用属性：

属性 | 描述
---- | ----
Text | 在复选框或单选按钮旁边显示的文本。
Checked | 制定是否被选中，默认为未选中。
GroupName | 控件归属组的名称。

#### 列表控件

ASP.NET 提供以下控件：

+ 下拉式列表，
+ 列表框，
+ 单选按钮列表，
+ 复选框列表，
+ 项目符号列表。

这些控件让用户可以从一个或多个项目列表中选择。列表框和下拉列表包含一个或多个列表项。这些列表可以通过代码或者由 ListItemCollection 编辑器被加载。

列表框控件的基本语法：

```html
<asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True"    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
</asp:ListBox>
```

下拉列表控件的基本语法：

```html
<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList>
```

列表框和下拉列表的通用属性：

属性 | 描述
---- | ----
Items | 代表了控件内项目的 ListItem 对象的集合。此属性回传 ListItemCollection 类型的对象。
Rows | 指定在框中显示的项目数。如果实际的列表中比显示的列表包含更多的行，则滚动条会被添加。
SelectedIndex | 当前所选项目的索引。如果一个以上的项目被选择，则第一个索引选择项目。如果没有选择项目，此属性的值为 -1。
SelectedValue | 当前选定项的值。如果一个以上的项目被选择，则第一项的值被选择。如果没有选中的项，该属性的值是一个空字符串("")。
SelectionMode | 表示一个列表框是否允许单个选择或多个选择。

每个列表项对象的通用属性：

属性 | 描述
---- | ----
Text | 为项目所显示的文本。
Selected | 表示项目是否被选定。
Value | 与项目相关的一串字符。

需要重点关注的是：

+ 如果您要在一个下拉列表或列表框中的项目工作，则需使用该控件的项目属性。此属性返回一个 ListItemCollection 对象，它包含该列表的所有项目。
+ 当用户从下拉列表或列表框中选择一个不同的项目时，SelectedIndexChanged 事件被引发。

#### ListItemCollection

ListItemCollection 对象是 ListItem 对象的集合。每个 ListItem 对象代表列表中的一个项目。在一个 ListItemCollection 中项目编号从 0 开始。

当一个列表框中的项目被加载过程中使用的字符串是比如：lstcolor.Items.Add ("Blue") 时，那么文字和列表项的值的属性设置是您指定的字符串值。为了以不同的方式设置，你必须创建一个列表项的对象，然后添加该项目到集合。

ListItemCollection 编辑器用于将项目添加到一个下拉列表或列表框。它被用来创建项目的静态列表。若要显示集合编辑器，则从智能标签菜单中选择编辑项目，或者选择控件，然后在属性窗口的项目属性中单击省略号按钮

ListItemCollection 的通用属性：

属性 | 描述
---- | ----
Item(integer) | 表示在指定索引处的项目的 ListItem 对象。
Count | 在集合中项目的个数。

ListItemCollection 的基本方法：
方法 | 描述
---- | ----
Add(string) | 在集合的末端增加一个新的项目并为项目文本属性分配字符串参数。
Add(ListItem) | 在集合末端添加一个新的项目。
Insert(integer, string) | 在集合中指定索引位置插入项目，并为项目文本属性分配字符串参数。
Insert(integer, ListItem) | 在集合中指定索引中的位置插入项目。
Remove(string) | 移除与文本值相同的字符串的项目。
Remove(ListItem) | 移除指定的项目。
RemoveAt(integer) | 作为整数移除在指定索引中的项目。
Clear | 移除集合中所有项目。
FindByValue(string) | 传回与字符串值相同的项目。
FindByValue(Text) | 传回与字符串文本相同的项目。

#### 单选按钮列表和复选框列表

单选按钮列表呈现互相排斥的选项列表。一个复选框列表列呈现独立选项的列表。这些控件包含 ListItem 对象的集合，它们可以通过控件的项目属性被参考。

单选按钮列表的基本语法：

```html
<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True"
   OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
</asp:RadioButtonList>
```

复选框列表的基本语法：

```html
<asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True"
   OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
</asp:CheckBoxList>
```

复选框和单选按钮列表的通用属性：

属性 | 描述
---- | ----
RepeatLayout | 该属性指定在提出格式化列表过程中是否使用标签或普通 HTML 流。默认为表格。
RepeatDirection | 它指定了方向，在该方向中控件可以被重复。可用的值是水平和垂直。默认是垂直的。
RepeatColumns | 当重复控件时，它指定了列的数字；默认为 0。

#### 项目符号列表和编号列表

项目符号列表控件创建项目符号列表或编号列表。这些控件包含 ListItem 对象的集合，它们可以通过控件的项目属性被参考。

项目符号列表的基本语法：

```html
<asp:BulletedList ID="BulletedList1" runat="server">
</asp:BulletedList>
```

项目符号列表的通用属性：

属性 | 描述
---- | ----
BulletStyle | 该属性指定样式和项目编号的外观或者数字。
RepeatDirection | 它指定了方向，在该方向中控件可以被重复。可用的值是水平和垂直。默认是垂直的。
RepeatColumns | 当重复控件时，它指定了列的数字；默认为 0。

#### 超链接控件

超链接控件就像 HTML \<a> 元素。

超链接控件的基本语法：

```html
<asp:HyperLink ID="HyperLink1" runat="server">
   HyperLink
</asp:HyperLink>
```

它具有以下属性：

属性 | 描述
---- | ----
ImageUrl | 由控件显示的图像的路径。
NavigateUrl | 目标链接地址。
Text | 作为链接显示的文本。
Target | 加载链接页面的窗口或框架。

#### 图像控件

若图片无法显示，图像控件则在网页，或者一些替代文本上显示图片。

图像控件的基本语法：

```html
<asp:Image ID="Image1" runat="server">
```

它具有以下重要属性：

属性 | 描述
---- | ----
AlternateText | 图片不存在时显示替代文本。
ImageAlign | 对齐选项控件。
ImageUrl | 由控件显示的图像的路径。

### 指令

ASP.NET 指令是指定可选设置的说明，如注册一个自定义的控制和页面的语言。这些设置介绍了 NET Framework 如何处理单页表单(.aspx)或用户控件(.ascx)网页。

下达指令的基本语法：

```html
<%@  directive_name attribute=value  [attribute=value]  %>
```

在这一部分中，我们将介绍 ASP.NET 指令，同时会在整个教程中应用大多数指令。

#### 应用程序指令

应用指令定义特定应用程序的属性。它是在 global.aspx 文件的顶部提供。

应用程序指令的基本语法：

```html
<%@ Application Language="C#" %>
```

应用程序指令的属性：

属性 | 描述
---- | ----
Inherits | 从类的名称中继承。
Description | 应用的文本描述。解析器和编译器忽略这一点。
Language | 应用在代码组中的语言。

#### 集合指令

集合指令链接着一个网页链接的组件或在分析时的应用程序。这可能会出现在整个应用类型链接 Global.asax 文件中，页面文件中，用于链接到另一个网页的用户控件中或用户控件中。

集合控件的基本语法是：

```html
<%@ Assembly Name ="myassembly" %>
```

集合控件的属性是：

属性 | 描述
---- | ----
Name | 被链接的集合组件的名称。
Src | 源文件被动态链接和编辑的路径。

#### 控制指令

控制指令是与用户控件一同使用并出现在用户控件(.ascx)文件中。

控制指令的基本语法是：

```html
<%@ Control Language="C#"  EnableViewState="false" %>
```

控制指令的属性是：

属性 | 描述
---- | ----
AutoEventWireup | 允许或禁用事件处理程序的自动关联的布尔值。
ClassName | 控件的文件名。
Debug | 许或禁用编辑调试符号的布尔值。
Description | 控制页面的文字说明，被编译器忽略。
EnableViewState | 页面请求为是否保持视图状态的布尔值。
Explicit | 在 VB 语言下，告知编辑器使用选项显示模式。
Inherits | 控制页面继承的类。
Language | 编码和脚本的语言。
Src | 代码隐藏类的文件名。
Strict | 在 VB 语言下，告知编辑器使用选项标准模式。

#### 工具指令

工具指令表明网页，母版页或者用户控制页必须执行具有详细说明的.Net 框架界面。

工具指令的基本语法是：

```html
<%@ Implements  Interface="interface_name" %>
```

#### 导入指令

导入指令导入一个命名空间到用户控制应用程序的页面。如果在 global.asax 文件中指定了 Import 指令，那么会将其应用到整个应用程序。如果它是在用户控制页面的网页中，则会将其应用到该网页或控件中。

导入指令的基本语法是：

```html
<%@ namespace="System.Drawing" %>
```

#### 主要指令

主要指令指定了一个页面文件作为主页。

样本主页指令的基本语法是：

```html
<%@ MasterPage Language="C#"  AutoEventWireup="true"  CodeFile="SiteMater.master.cs" Inherits="SiteMaster"  %>
```

#### MasterType 指令

MasterType 指令指定一个类名到页面的主属性，强化其类型。

母版式指令的基本语法是：

```html
<%@ MasterType attribute="value"[attribute="value" ...]  %>
```

#### 输出缓存指令

输出缓存指令控制网页或用户控件的输出缓存策略。

输出缓存指令的基本语法：

```html
<%@ OutputCache Duration="15" VaryByParam="None"  %>
```

#### 页面指令

页面指令定义特定的页面分析器和编译器的页面文件的属性。

页面指令的基本语法是：

```html
<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Default.aspx.cs"  Inherits="_Default"  Trace="true" %>
```

页面指令的属性是：

属性 | 描述
---- | ----
AutoEventWireup | 允许或禁用正在自动绑定到方法页面事件的布尔值;例如，Page_Load。
Buffer | 允许或禁用 HTTP 响应缓冲的布尔值。
ClassName | 页面的类别名称。
ClientTarget | 服务器控件应呈现的内容的浏览器
CodeFile | 代码隐藏文件的名称。
Debug | 允许或禁止使用调试符号编译的布尔值。
Description | 页面的文件说明，由解析器忽略。
EnableSessionState | 启用或禁用页面会话状态为只读。
EnableViewState | 允许或禁止跨页请求视图状态的布尔值。
ErrorPage | 未经处理的页面异常发生的情况下的重定地址。
Inherits | 后台代码或其他类的名称。
Language | 代码的编程语言。
Src | 后台代码类的文件名。
Trace | 启用或禁用跟踪。
TraceMode | 表示跟踪信息的显示方式，并按照时间或者类别排序。
Transaction | 表示交易是否被支持。
ValidateRequest | 表示所有输入数据是否被有效验证为 hardcoded 列表值得布尔值。

#### 前页型指令

前页型指令为一个页面分配类别，使得该页面类型被强化。

前页型指令的样本的基本语法：

<%@ PreviousPageType attribute="value"[attribute="value" ...]   %>

#### 参考指令

参考指令表明另一个页面或用户控件应编译和链接到当前页面。

参考指令的基本语法是：

```html
<%@ Reference Page ="somepage.aspx" %>
```

#### 注册指令

注册指令用于注册定制服务器控件和用户控件。

注册指令的基本语法是：

```html
<%@ Register Src="~/footer.ascx" TagName="footer" TagPrefix="Tfooter" %>
```

### 管理状态

超文本传输协议(HTTP)是一种无状态协议。当客户端从服务器断开连接时，ASP.NET 引擎将丢弃页面对象。这样一来，每个 Web 应用程序能够扩展到同时用于大量请求，但是不会耗尽服务器内存。

然而，需要有一些技术来存储各个请求之间的信息并在需要时取回。这个信息则称为状态，即所有控件的当前值和在当前会话中当前用户使用的变量。

ASP.NET 管理四种状态：

+ 视图状态
+ 控制状态
+ 会话状态
+ 应用程序状态

#### 视图状态

视图状态是页面及其所有控件的状态。它通过 ASP.NET 框架的反馈保持不变。

当一个页面被发送回客户端，这些页面变化的属性及其控件是确定的，并存储在名为 _VIEWSTATE 的一个隐藏输入字段的值内。当页面被再次回发时，_VIEWSTATE 字段随 HTTP 请求被发送到服务器。

视图状态可以对以下内容启用或者禁用：

+ **整个应用程序**：设置 web.config 文件中 部分的 EnableViewState 属性。
+ **一个页面**：设置页面指令的 EnableViewState 属性为 <%@ Page Language="C#" EnableViewState="false" %>
+ **一个控件**：设置控件 .EnableViewState 属性。

它通过使用视图状态对象，该对象是由被一组视图状态项目定义的 StateBag 类别定义的。该 StateBag 是一种数据结构，包含属性值对并被存储为与对象相关联的字符串。

StateBag 类具有以下属性：

属性 | 描述
---- | ----
Item(name) | 具有指定名称的视图状态的值，是 StateBag 的默认属性。
Count | 状态集合中的项目名称。
Keys | 集合中所有项目的密钥集合。
Values | 集合中所有项目的值的集合。

StateBag 类具有以下方法：

方法 | 描述
---- | ----
Add(name, value) | 添加一个项目到视图状态集合，更新现有项目。
Clear | 移除集合中所有项目。
Equals(Object) | 确定指定的对象是否等于当前对象。
Finalize | 允许释放资源并执行其他清理操作。
GetEnumerator | 返回存储在 StateBag 对象中重复的 StateItem 对象的密钥/值对的计数器。
GetType | 获取当前实例的类型。
IsItemDirty | 检查存储在 StateBag 对象以确认其是否已被修改。
Remove(name) | 移除制定项目。
SetDirty | 设置 StateBag 对象的状态以及每个由其包含的 StateItem 对象的 Dirty 属性。
SetItemDirty | 为在 StateBag 对象中的指定 StateItem 对象设置 Dirty 属性。
ToString | 返回代表状态包对象的字符串。

#### 控制状态

控制状态不能被直接修改，存取或禁用。

#### 会话状态

当用户连接到 ASP.NET 网站，一个新的会话对象将被创建。当会话状态开启时，新的会话状态会为每一个新的请求而创建。这种会话状态对象会成为运行环境中的一部分并可通过页面使用。

会话状态通常用于存储应用程序数据，比如详细目录，供应商清单，客户记录或购物车。它可以存储用户的信息及其偏好信息，并保存用户未决定的路径。

会话由 120 位的 SessionID 识别和跟踪，从客户端传递到服务器并且作为 cookie 或修改的 URL 回传。SessionID 是全球唯一的，随机的。

会话状态对象由 HttpSessionState 类创建，它定义会话状态项集合。

HttpSessionState 类具有以下属性：

属性 | 描述
---- | ----
SessionID | 唯一的会话标识符。
Item(name) | 具有指定名称的会话状态项的值，是 HttpSessionState 类的默认属性。
Count | 会话状态集合中项的数量。
TimeOut | 获取和设置时间量，几分钟内，在供应商停止会话状态前在请求间被允许。

HttpSessionState 类有以下方法：

方法 | 描述
---- | ----
Add(name, value) | 添加新的项到会话状态集合。
Clear | 移除会话状态集合中所有项。
Remove(name) | 移除会话状态集合中的指定项。
RemoveAll | 移除会话状态集合中所有密钥和值。
RemoveAt | 从会话状态集合中删除指定索引处的项。

会话状态对象是一个名 - 值对，它可以从会话状态对象中存储和检索信息。同样地，您可以使用以下代码：

```cs
void StoreSessionInfo()
{
   String fromuser = TextBox1.Text;
   Session["fromuser"] = fromuser;
}

void RetrieveSessionInfo()
{
   String fromuser = Session["fromuser"];
   Label1.Text = fromuser;
}
```

以上代码只存储在会话词典对象中的字符串，但是，它可以存储所有原始数据类型和由原始数据类型组成的阵列，DataSet, DataTable, HashTable, 和图像对象，以及继承 ISerializable 对象的任意用户定义的类。

##### session的存储方式和配置

Session又称为会话状态，是Web系统中最常用的状态，用于维护和当前浏览器实例相关的一些信息。我们控制用户去权限中经常用到Session来存储用户状态，这篇文章会讲下Session的存储方式、在web.config中如何配置Session、Session的生命周期等内容。

1、Session的存储方式。

　　session其实分为客户端Session和服务器端Session。

　　当用户首次与Web服务器建立连接的时候，服务器会给用户分发一个 SessionID作为标识。SessionID是一个由24个字符组成的随机字符串。用户每次提交页面，浏览器都会把这个SessionID包含在 HTTP头中提交给Web服务器，这样Web服务器就能区分当前请求页面的是哪一个客户端。这个SessionID就是保存在客户端的，属于客户端Session。

　　其实客户端Session默认是以cookie的形式来存储的，所以当用户禁用了cookie的话，服务器端就得不到SessionID。这时我们可以使用url的方式来存储客户端Session。也就是将SessionID直接写在了url中，当然这种方法不常用。

　　我们大多数提到的Session都是指服务器端Session。他有三种存储方式(自定义存储在这里不做讨论)：

　　1.1保存在IIS进程中：

　　保存在IIS进程中是指把Session数据保存在IIS的运行的进程中，也就是inetinfo.exe这个进程中，这也是默认的Session的存方式，也是最常用的。

　　这种方式的优点是简单，性能最高。但是当重启IIS服务器时Session丢失。

　　1.2.保存在StateServer上

　　这种存储模式是指将Session数据存储在一个称为Asp.Net状态服务进程中，该进程独立于Asp.Net辅助进程或IIS应用程序池的单独进程，使用此模式可以确保在重新启动Web应用程序时保留会话状态，并使会话状态可以用于网络中的多个Web服务器。

　　1.3.保存在SQL Server数据库中

　　可以配置把Session数据存储到SQL Server数据库中，为了进行这样的配置，程序员首先需要准备SQL Server数据服务器，然后在运行.NET自带安装工具安装状态数据库。

　　这种方式在服务器挂掉重启后都还在，因为他存储在内存和磁盘中。

　　下面是这三种方式的比较：

x项目  | InProc | StateServer |SQLServer
  --- | ----- | ---------- | --------
存储物理位置 | IIS进程（内存） | Windows服务进程（内存） |SQLServer数据库（磁盘）
存储类型限制 | 无限制 | 可以序列化的类型 | 可以序列化的类型
存储大小限制 | 无限制
使用范围 | 当前请求上下文，对于每个用户独立
生命周期 | 第一次访问网站的时候创建Session超时后销毁
优点 | 性能比较高 | Session不依赖Web服务器，不容易丢失
缺点 | 容易丢失 | 序列化与反序列化消耗CPU资源 | 序列化与反序列化消耗CPU资源，从磁盘读取Session比较慢
使用原则 |不要存放大量数据

　　2、在web.config中配置Session

　　Web.config文件中的Session配置信息：

```xml
<sessionState mode="Off|InProc|StateServer|SQLServer"cookieless="true|false"timeout="number of minutes"stateConnectionString="tcpip=server:port"sqlConnectionString="sql connection string"stateNetworkTimeout="number of seconds"/>
```

　　mode 设置将Session信息存储到哪里：

    　　　　— Off 设置为不使用Session功能；

    　　　　— InProc 设置为将Session存储在进程内，就是ASP中的存储方式，这是默认值；

    　　　　— StateServer 设置为将Session存储在独立的状态服务中；

    　　　　— SQLServer 设置将Session存储在SQL Server中。

　　cookieless 设置客户端的Session信息存储到哪里：

　　　　— ture 使用Cookieless模式；这时客户端的Session信息就不再使用Cookie存储了，而是将其通过URL存储。比如网址为<http://localhost/MyTestApplication/(ulqsek45heu3ic2a5zgdl245)/default.aspx>

　　　　— false 使用Cookie模式，这是默认值。

　　timeout 设置经过多少分钟后服务器自动放弃Session信息。默认为20分钟。

　　stateConnectionString 设置将Session信息存储在状态服务中时使用的服务器名称和端口号，例如："tcpip=127.0.0.1:42424”。当mode的值是StateServer是，这个属性是必需的。（42424是默认端口）。

　　sqlConnectionString 设置与SQL Server连接时的连接字符串。例如"data source=localhost;Integrated Security=SSPI;Initial Catalog=northwind"。当mode的值是SQLServer时，这个属性是必需的。

　　stateNetworkTimeout 设置当使用StateServer模式存储Session状态时，经过多少秒空闲后，断开Web服务器与存储状态信息的服务器的TCP/IP连接的。默认值是10秒钟。

　　下面来说下用StateServer和SqlServer来存储Session的方法

　　2.1 StateServer

　　第1步是打开状态服务。依次打开“控制面板”→“管理工具”→“服务”命令，找到ASP.NET状态服务一项，右键单击服务选择启动。

　　如果你正式决定使用状态服务存储Session前，别忘记修改服务为自启动（在操作系统重启后服务能自己启动）以免忘记启动服务而造成网站Session不能使用

　　第2步，在system.web节点中加入：stateNetworkTimeout="20"> stateConnectionString表示状态服务器的通信地址（IP：服务端口号）。由于我们现在在本机进行测试，这里设置成本机地址127.0.0.1。状态服务默认的监听端口为42422。当然，您也可以通过修改注册表来修改状态服务的端口号。

　　(修改注册表来修改状态服务的端口号的方法：在运行中输入regedit启动注册表编辑器—依次打开HKEY_LOCAL_MACHINESYSTEMCurrentControlSetServicesaspnet_stateParameters节点，双击Port选项—选择基数为十进制，然后输入一个端口号即可。)

　　2.2 SqlServer

　　在SQL Server中执行一个叫做InstallSqlState.sql的脚本文件。这个脚本文件将在SQL Server中创建一个用来专门存储Session信息的数据库，及一个维护Session信息数据库的SQL Server代理作业。我们可以在以下路径中找到那个文件：

[system drive]\winnt\Microsoft.NET\Framework\[version]\

然后打开查询分析器，连接到SQL Server服务器，打开刚才的那个文件并且执行。稍等片刻，数据库及作业就建立好了。这时，你可以打开企业管理器，看到新增了一个叫ASPState的数据库。

　　修改mode的值改为SQLServer。注意，还要同时修改sqlConnectionString的值，格式为：sqlConnectionString="data source=localhost; Integrated Security=SSPI;"(这种是通过windows集成身份验证)

　　3、Session的生命周期

　　Session的生命周期其实在第一节已经讲过了，和不同的存储过程有关。

　　4、遍历以及销毁Session

　　4.1遍历：

System.Collections.IEnumerator SessionEnum = Session.Keys.GetEnumerator();
while (SessionEnum.MoveNext())
{
    Response.Write(Session[SessionEnum.Current.ToString()].ToString() + " ");
}

原文出处：[http://www.cnblogs.com/lenther2002/p/4822302.html](http://www.cnblogs.com/lenther2002/p/4822302.html)

##### aps.net session全面介绍(生命周期，超时时间)

Asp.Net中的Session与Cookie最大的区别在于：Cookie信息全部存放于客户端，Session则只是将一个ID存放在客户端做为与服务端验证的标记，而真正的数据都是放在服务端的内存之中的。　　在传统web编程语言(比如asp)中，session的...

  Asp.Net中的Session与Cookie最大的区别在于：Cookie信息全部存放于客户端，Session则只是将一个ID存放在客户端做为与服务端验证的标记，而真正的数据都是放在服务端的内存之中的。

　　在传统web编程语言(比如asp)中，session的过期完全是按照TimeOut来老老实实处理的，超时值默认是20分钟，但问题是：通常有很多用户只看一眼网页，然后就关浏览器走人了，这种情况下，服务端内存里还长久保存着Session的数据，如果这种用户很多，对服务器资源无疑是一种浪费。默认情况下，系统采用的是InProc模式，即进程内模式。这种情况下，Session是保存在Asp.Net工作进程映射的内存中的，问题是Asp.Net工作进程为了维护良好的平均性能，会被系统经常回收。我们在IIS里可以配置自动回收(比如按时间周期回收，或者当内存使用达到多少值时自动回收)。　当Asp.Net工作进程被回收时，其映射的内存全部被清空并初始化，以便其它程序可以使用，所以Session也跟着一并消失了，就这是为什么Sesssion会无故消失的主要原因。

一、session是怎么存储，提取的？

1.在服务器端有一个session池，用来存储每个用户提交session中的数据，Session对于每一个客户端（或者说浏览器实例）是“人手一份”，用户首次与Web服务器建立连接的时候，服务器会给用户分发一个SessionID作为标识。SessionID是一个由24个字符组成的随机字符串。用户每次提交页面，浏览器都会把这个SessionID包含在HTTP头中提交给Web服务器，这样Web服务器就能区分当前请求页面的是哪一个客户端,而这个SessionID是一cookie的方式保存的在客户端的内存中的，如果想要得到Session池中的数据，服务器就会根据客户端提交的唯一SessionID标识给出相应的数据返回。

2.输入正确的账号密码，点击登录，页面就会输出  “admin --- 点击登录”

二、Session池中每个客户端的数据是怎么存储的？

1.存储在Session池中的数据是全局型的数据，可以跨页面访问，每个SessionID中只存储唯一的数据，如：首先你这样设定：session["userName"]="admin",然后你在会话还没结束的session还没过期的情况下，你又设定：session["userName"]="123";这样这个SessionID没变，然而Session池中的数据则被覆盖。此时session["userName"]的值就是“123”，而不是其它。

2.Session池中的数据不能跨进程访问。如：打开login.aspx页面写入session[“userName”]="admin";然后login页面不关闭，即此会话不结束，在这是你再在另外一个浏览器中打开一个login.aspx页面则session["userName"]=null

3.输入账号密码，点击登录页面输出  “admin --- 点击登录” ，如果紧接着点击获取session按钮，则页面只输出"admin--- 点击获取session"，如果页面不关闭，打开另外一个浏览器，点击获取session按钮，则页面没法应。

三丶session的声明周期与销毁

1.session存储数据计时是滚动计时方式。具体是这样的，如果你打开写入session，从写入开始，此页面如果一直没有提交操作，则默认时间是20分钟，20分钟后session被服务器自动销毁，如过有提交操作，服务器会从提交后重新计时以此类推，直至设定时间内销毁。

2.可以设置session的销毁时间。上面代码有提到。

四丶session中保存的数据是在服务端的，而每个用户如进行登录操作，都要进行session数据写入，所以建议慎用session，就是少用。

五丶代码举例:

```html
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function getSessionClick(action) {   //这个函数是为了知道哪一个提交按钮被点击
            $("#hidlgc").val("");  //清空隐藏值
            $("#hidlgc").val(action);   //给隐藏控件赋值
        }
    </script>
</head>
<body>
    <form id="form1" method="post" action="MySession.aspx">
         <table>
            <tr>
                <td>账号：</td><td><input type="text" name="txtUid" /></td>`
            </tr>
             <tr>
                <td>密码：</td><td><input type="password" name="txtPwd" /></td>
             </tr>
             <tr>
                <td colspan="2">
                    <input type="hidden" value="" id="hidlgc" name="hidlgclick" />
                    <input onclick="getSessionClick('lgclick')" type="submit" value="登录" />
                    <input type="submit" onclick="getSessionClick('getSession')" value="获取session" />
                    <input type="submit" onclick="getSessionClick('backLg')" value="退出登录" />
                </td>
             </tr>
         </table>
    </form>
</body>
```

asp.net后台处理代码:

```cs
protected void Page_Load(object sender, EventArgs e)
        {
            //把用户id写入session中
            if (Request.Form["hidlgclick"] == "lgclick")
            {
                if(Request.Form["txtUid"].ToString()=="admin"&&Request.Form["txtUid"].ToString()=="admin") //判断用户登录
                {
                    Session["userName"] = Request.Form["txtUid"].ToString();  //把用户id保存到session中
                    Response.Write(Session["userName"].ToString()+"---点击登录"); //获取session，并写入页面
                }
            }
            //获取Session
            if (Request.Form["hidlgclick"] == "getSession")
            {
                if (Session["userName"] != null)
                {
                    Response.Write(Session["userName"].ToString() + "---点击获取session"); //获取session，并写入页面
                }
            }
            //取消当前会话，相当于注销（退出登录）。
            if (Request.Form["hidlgclick"] == "backLg")
            {
                Session.Abandon();
            }
        }
```

设置session的过期时间:

```html
<system.web>
   <sessionState timeout="40"></sessionState>  <!---设置session的过期时间，时间以分钟为单位-->
```

## ASP.NET Core

### ASP.NET Core简介

ASP.NET Core 是一个跨平台的高性能开源框架，用于生成基于云且连接 Internet 的新式应用程序。 使用 ASP.NET Core，可以：

+ 建置 Web 应用程式和服务、IoT 应用和移动后端。
+ 在 Windows、macOS 和 Linux 上使用喜爱的开发工具。
+ 部署到云或本地。
+ 在 .NET Core 或 .NET Framework 上运行。

### .NET Core 优势

+ 生成 Web UI 和 Web API 的统一场景。
+ 集成新式客户端框架和开发工作流。
+ 基于环境的云就绪配置系统。
+ 内置依赖项注入。
+ 轻型的高性能模块化 HTTP 请求管道。
+ 能够在 IIS、Nginx、Apache、Docker 上进行托管或在自己的进程中进行自托管。
+ 定目标到 .NET Core 时，可以使用并行应用版本控制。
+ 简化新式 Web 开发的工具。
+ 能够在 Windows、macOS 和 Linux 进行生成和运行。
+ 开放源代码和以社区为中心。

### VS Core开始一个.Net Core web Razor项目

打开命令提示行（RazorPagesMovies是项目文件夹），进入工作目录后输入：  
dotnet new webapp -o RazorPagesMovie  
cd RazorPagesMovie  
dotnet run

### ASP.Net Core 常用命令

```shell
$ dotnet new -h
使用情况: new [选项]

选项:
  -h, --help          显示有关此命令的帮助。
  -l, --list          列出包含指定名称的模板。如果未指定名称，请列出所有模板。
  -n, --name          正在创建输出的名称。如果未指定任何名称，将使用当前目录的名                                                                                                                                                                                               称。
  -o, --output        要放置生成的输出的位置。
  -i, --install       安装源或模板包。
  -u, --uninstall     卸载一个源或模板包。
  --type              基于可用的类型筛选模板。预定义的值为 "project"、"item" 或 "other"。
  --force             强制生成内容，即使该内容会更改现有文件。
  -lang, --language   指定要创建的模板的语言。

模板                                                短名称              语言                                                                                                                                                                                                               标记
--------------------------------------------------------------------------------                                                                                                                                                                                               ------------------------
Console Application                               console          [C#], F#, VB                                                                                                                                                                                                     Common/Console
Class library                                     classlib         [C#], F#, VB                                                                                                                                                                                                     Common/Library
Unit Test Project                                 mstest           [C#], F#, VB                                                                                                                                                                                                     Test/MSTest
xUnit Test Project                                xunit            [C#], F#, VB                                                                                                                                                                                                     Test/xUnit
ASP.NET Core Empty                                web              [C#], F#                                                                                                                                                                                                         Web/Empty
ASP.NET Core Web App (Model-View-Controller)      mvc              [C#], F#                                                                                                                                                                                                         Web/MVC
ASP.NET Core Web App                              razor            [C#]                                                                                                                                                                                                             Web/MVC/Razor Pages
ASP.NET Core with Angular                         angular          [C#]                                                                                                                                                                                                             Web/MVC/SPA
ASP.NET Core with React.js                        react            [C#]                                                                                                                                                                                                             Web/MVC/SPA
ASP.NET Core with React.js and Redux              reactredux       [C#]                                                                                                                                                                                                             Web/MVC/SPA
ASP.NET Core Web API                              webapi           [C#], F#                                                                                                                                                                                                         Web/WebAPI
global.json file                                  globaljson                                                                                                                                                                                                                        Config
NuGet Config                                      nugetconfig                                                                                                                                                                                                                       Config
Web Config                                        webconfig                                                                                                                                                                                                                         Config
Solution File                                     sln                                                                                                                                                                                                                               Solution
Razor Page                                        page                                                                                                                                                                                                                              Web/ASP.NET
MVC ViewImports                                   viewimports                                                                                                                                                                                                                       Web/ASP.NET
MVC ViewStart                                     viewstart                                                                                                                                                                                                                         Web/ASP.NET

Examples:
    dotnet new mvc --auth Individual
    dotnet new page --namespace
    dotnet new --help
```