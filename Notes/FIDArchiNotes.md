# FID软件架构研究

## 架构

### 软件架构设计说明书

### [STAThread]

每个Thread都有一个关于ApartmentState（线程套间状态）的属性，可以把它设置为STA，MTA，UNKNOW。

当指定一个工程的启动窗口的时候,需要在该窗口类中申明一个Main()方法，并为这个方法设置[STAThread]属性。

[*why*]

## Word生成报告

### [serializable]

[Serializable特性](http://www.cnblogs.com/GreenLeaves/p/6753261.html)

## 界面

## 工具函数说明

## 小工具

### 自动编译脚本

使用windows脚本从SVN下载代码，进行各个模块的编译，并生成压缩包。
本程序共有三个solution的编译和调用这三个编译脚本及完成打包工作的main.bat。
后续的自动生成安装文件未实现

#### 编译打包说明

与本程序实际实现有一定区别

>1.运行E:\SWProject\ContinueCompile\ump\script\main.bat,完成编译与打包资源准备
2.打开E:\SWProject\Install\UMPInstall\UMPInstall.ism, 执行Build->Build SINGLE_EXE_IMAGE,执行安装包制作
3.在 E:\SWProject\Install\UMPInstall\UMPInstall\Media\SINGLE_EXE_IMAGE\Disk Images 中得到安装包文件夹，以带有时间版本名称压缩，得到安装包

#### main.bat

```shell
E:
set ScriptPath=E:\RTProject\ContinueCompile\FIDContinueCompile\script
set ScrBootPath=E:\RTProject\ContinueCompile\FIDContinueCompile\FIDcompileWorkDir\scr
set CompileBinDirPath=E:\RTProject\ContinueCompile\FIDContinueCompile\FIDcompileWorkDir\bin

set devenvPath="D:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe"
set ZipResultPath=E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult


set TimeStr1=%date:~0,4%%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%%time:~6,2%
::替换空格为0
set TimeStr=%TimeStr1: =0%


set ComplileOutLogFilePath=E:\RTProject\ContinueCompile\FIDContinueCompile\Log\ComplieLog%TimeStr%.txt

::重建编译结果bin目录
rd "%CompileBinDirPath%" /s /q
md "%CompileBinDirPath%"



::echo %TimeStr%
::set FileNameStr=nnn%TimeStr%.zip
::echo %FileNameStr%

echo %ComplileOutLogFilePath%

::基础库
cd %ScriptPath%
call BaseLibSvn.bat %ScrBootPath% %devenvPath% %ScriptPath% %ComplileOutLogFilePath%

::DomainModel
cd %ScriptPath%
call DomainModel.bat %ScrBootPath% %devenvPath% %ScriptPath% %ComplileOutLogFilePath%


::FID

::自动拷贝基础库下所有内容到FID下
xcopy %CompileBinDirPath%\RTBaselib\*.* %CompileBinDirPath%\FID\ /y /e /i /q

::自动拷贝StabilityDomainRemoteService下所有内容到FID下
xcopy %CompileBinDirPath%\StabilityDomainRemoteService\*.* %CompileBinDirPath%\FID\ /y /e /i /q


cd %ScriptPath%
call FID.bat %ScrBootPath% %devenvPath% %ScriptPath% %ComplileOutLogFilePath%


::制作压缩包
"C:\Program Files\WinRAR\WinRAR.exe" a -ep1 "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\RTBaseLib%TimeStr%.rar" "%CompileBinDirPath%\RTBaseLib"
"C:\Program Files\WinRAR\WinRAR.exe" a -ep1 "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\FID%TimeStr%.rar" "%CompileBinDirPath%\FID"
"C:\Program Files\WinRAR\WinRAR.exe" a -ep1 "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\RTTask%TimeStr%.rar" "%CompileBinDirPath%\RTTask"
"C:\Program Files\WinRAR\WinRAR.exe" a -ep1 "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\StabilityDomainRemoteService%TimeStr%.rar" "%CompileBinDirPath%\StabilityDomainRemoteService"

::准备打包环境
::call InstallMakeMain.bat


set ServerPath=W:\研发事业部\FID编译结果\CurrentVersionCompileResult\ComplieLog%TimeStr%.txt
copy %ComplileOutLogFilePath% %ServerPath%


copy "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\RTBaseLib%TimeStr%.rar" "W:\研发事业部\FID编译结果\CurrentVersionCompileResult\RTBaseLib%TimeStr%.rar"
copy "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\FID%TimeStr%.rar" "W:\研发事业部\FID编译结果\CurrentVersionCompileResult\FID%TimeStr%.rar"
copy "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\FID%TimeStr%.rar" "W:\研发事业部\FID编译结果\CurrentVersionCompileResult\RTTask%TimeStr%.rar"
copy "E:\RTProject\ContinueCompile\FIDContinueCompile\ZipResult\FID%TimeStr%.rar" "W:\研发事业部\FID编译结果\CurrentVersionCompileResult\StabilityDomainRemoteService%TimeStr%.rar"

pause
```

#### BaseLibSvn.bat 用于完成基础库的编译

```shell
E:
set ScrBootPath=%1
set devenvPath=%2
set ComplileOutLogFilePath=%4
::echo %devenvPath%
::echo %ScrBootPath%
::pause


rd "%ScrBootPath%" /s /q
md "%ScrBootPath%"
cd "%ScrBootPath%"

svn export https://vsvn.sh.richio.com/svn/RTDevelopDpartment/RTBaselib/Code
ren "%ScrBootPath%\Code" RTBaseLib

::
%devenvPath% "%ScrBootPath%\RTBaseLib\RTBaseLibCompile.sln" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"


::远程调用基础支持
svn export https://vsvn.sh.richio.com/svn/RTDevelopDpartment/RTRemoteTask
%devenvPath% "%ScrBootPath%\RTRemoteTask\RTTaskManager.sln" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"
%devenvPath% "%ScrBootPath%\RTRemoteTask\RTTaskCenter\RTTaskCenter.csproj" /Build "Debug|x86" /out "%ComplileOutLogFilePath%"
```

#### DomainModel.bat领域模型的编译

```shell
E:
set ScrBootPath=%1
set devenvPath=%2
set ComplileOutLogFilePath=%4
echo %devenvPath%

rd "%ScrBootPath%" /s /q
md "%ScrBootPath%"
cd "%ScrBootPath%"

::md "%ScrBootPath%\UMPDataRemoteSever"
::cd "%ScrBootPath%\UMPDataRemoteSever"


:://下载代码
svn export https://vsvn.sh.richio.com/svn/RTDevelopDpartment/FloatDesignIntegrate/Code/DomainModel
::ren "%ScrBootPath%\CodeScr" "FID"


%devenvPath% "%ScrBootPath%\DomainModel\HydrodynamicDomain\HydrodynamicDomainModel\HydrodynamicDomainModel.csproj" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"
%devenvPath% "%ScrBootPath%\DomainModel\MooringRiserDomain\MooringRiserDomainModel\MooringRiserDomainModel.csproj" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"

%devenvPath% "%ScrBootPath%\DomainModel\StabilityDomain\StabilityDomainModel\StabilityDomainModel.csproj" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"
%devenvPath% "%ScrBootPath%\DomainModel\StabilityDomain\StabilityDomainRemoteService\StabilityDomainRemoteService.csproj" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"
%devenvPath% "%ScrBootPath%\DomainModel\StabilityDomain\StabilityDomainRemoteServiceForm\StabilityDomainRemoteServiceForm.csproj" /Build "Debug|x86" /out "%ComplileOutLogFilePath%"

%devenvPath% "%ScrBootPath%\DomainModel\StructAnalyzeDomain\StructAnalyzeDomainModel\StructAnalyzeDomainModel.csproj" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"
```

#### FID.bat FID主程序的编译

```shell
E:
set ScrBootPath=%1
set devenvPath=%2
set ComplileOutLogFilePath=%4
echo %devenvPath%

rd "%ScrBootPath%" /s /q
md "%ScrBootPath%"
cd "%ScrBootPath%"


:://下载代码
svn export https://vsvn.sh.richio.com/svn/RTDevelopDpartment/FloatDesignIntegrate/Code/FID
::ren "%ScrBootPath%\CodeScr" "FID"


%devenvPath% "%ScrBootPath%\FID\FID.sln" /Build "Debug|Anycpu" /out "%ComplileOutLogFilePath%"
%devenvPath% "%ScrBootPath%\FID\FID\FID.csproj" /Build "Debug|x64" /out "%ComplileOutLogFilePath%"
```

#### InstallMakeMain.bat 安装包制作脚本**本程序未进行实现**

```shell
E:

set CompileBinDirPath=E:\SWProject\ContinueCompile\ump\umpcompile\bin\UMP
set InstallBinDirPath=E:\SWProject\bin\UMP

set DomainDir=E:\SWProject\UMP\DomainResDir

rd "%InstallBinDirPath%" /s /q

echo d | xcopy "%CompileBinDirPath%" "%InstallBinDirPath%" /e

::重建Scr目录
rd "%DomainDir%" /s /q
md "%DomainDir%"
cd "%DomainDir%"

move "%InstallBinDirPath%\DomainResDir\Assembly" "%DomainDir%\Assembly"

move "%InstallBinDirPath%\DomainResDir\CAD111" "%DomainDir%\CAD111"

move "%InstallBinDirPath%\DomainResDir\CADAssembly" "%DomainDir%\CADAssembly"

move "%InstallBinDirPath%\DomainResDir\CAEModel" "%DomainDir%\CAEModel"

move "%InstallBinDirPath%\DomainResDir\CAEResult" "%DomainDir%\CAEResult"

move "%InstallBinDirPath%\DomainResDir\CFD" "%DomainDir%\CFD"

::move "%InstallBinDirPath%\DomainResDir\Optimization" "%DomainDir%\Optimization"
::move "%InstallBinDirPath%\DomainResDir\Report" "%DomainDir%\Report"
::move "%InstallBinDirPath%\DomainResDir\Txt" "%DomainDir%\Txt"


echo "OK"
pause



```