# Note

## .NET Core

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

### .NET Core命令组织和测试项目

#### .NET Core文件组织

典型的组织类型  

```(File Organizing)
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

```(console)  
dotnet add reference ../../src/NewTypes/NewTypes.csproj
```

也可以通过在NewTypesTests.csproj文件中添加\<ItemGroup>节点，手动添加项目引用。

```(xml)
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

```(File Organizing)
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

```(xml)
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

-----------------------------------------------------------------------

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
