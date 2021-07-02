# 本文是中文版的README文档 this README is written in Chinese #
## 1 项目自述 ##

### 1.1项目自述 ###
--------------------------------------------------------------
* by AugustFlugur
* 本项目基于C# .NET Framework 4.6.1、System.Data.SQLite，是一个用于清理**无效注册表**的窗体程序。
* 为了保证能够同时在X86与X64环境中稳定运行，本项目为32位程序。
* 这个项目目前还在开发中，功能十分简陋，不建议使用。
* 项目目前的主要功能有：删除SOFTWARE\下为空且没有子键的键、删除OpenWithProgids\下无效程序信息。
### 1.2项目文件路径 ###
--------------------------------------------------------------
项目根下有两个文件夹RegistryDesktop Code与RegistryDesktop Installer，分别是源码文件与安装文件。
RegistryDe Code为一个Visual Studio解决方案，分为四个项目，其中有两个重要的项目。
RegistryDesktop（窗体项目）、RegistryD（RegistryD.dll程序集）为程序必要部分，TestFordll是一个用于测试的项目，里面没有代码。
RegistrySetup为SetupProject项目。