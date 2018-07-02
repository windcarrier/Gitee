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
