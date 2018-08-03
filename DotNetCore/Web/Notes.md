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

>[极客学院 ASP.NET 教程](http://wiki.jikexueyuan.com/project/asp-net/environment-setup.html)
>[ASP.NET 学习总结（50+篇）](http://www.shouce.ren/api/view/a/15487)
>[.NET Core+MySql+Nginx 容器化部署](https://www.jianshu.com/p/2a755277a1e6)
>[Asp.net mvc 知多少（一）](https://www.jianshu.com/p/5f6156cacc76)

### ASP.Net 简介

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
+ 服务器
+ 用户
+ 跟踪

我们会在适当的时间里讨论每一个对象。在本教程中我们将会探索 Server 对象，Request 对象和 Response 对象。

#### Server 对象

ASP.NET 中的服务器对象是 **System.Web.HttpServerUtility** 类的一个实例。The HttpServerUtility 类提供了大量的属性和方法来执行不同的工作

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