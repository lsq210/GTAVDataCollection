# GTAVDataCollection

[GTAVDataCollection](https://github.com/lsq210/GTAVDataCollection/) 是一个 Grand Theft Auto V 的三方模组，用于从 GTAV 中提取数据，其中包含用于机器学习训练的仿现实图片和标签

![demo image](resources/bbox.jpg)

[English](./README.md) | 简体中文

## 🛠️ 环境要求

- [ScriptHookV](http://www.dev-c.com/gtav/scripthookv/)
- [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet/releases)
- [Scripted Camera Tool](https://www.gta5-mods.com/scripts/scripted-camera-tool-1-0)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs)
- [.NET Framework ≥ 4.8](https://www.visualstudio.com/cs/downloads/)
- 其它通过 Nuget 包管理器管理的模块

## 🚀 快速开始

1. 下载并安装 ScriptHookV、ScriptHookVDotNet 和 Scripted Camera Tool
2. 下载[二进制文件](https://github.com/lsq210/GTAVDataCollection/releases/)并拷贝到 `Grand Theft Auto V/scripts/` 目录
3. 启动游戏
4. 按 T 对相机进行设置
5. 按 Y 开始或结束数据提取工作。数据将被保存到 `Grand Theft Auto V/data/` 目录

## 💿 数据集

### 下载

基于 GTAVDataCollection 构建了一个大规模遥感图像车辆目标检测的数据集：GTA5-Vehicle。请注意数据只能用来进行学术研究。

[百度网盘](https://pan.baidu.com/s/1ad8-_92C9RGL2wQpRCAjGA?pwd=8ply)

### 目标类别

数据集中包含15类车辆目标，分别是Compacts，Sedans，SUVs，Coupes，Muscle，SportsClassics，Sports，Super，OffRoad，Industrial，Utility，Vans，Service，Emergency，Commercial。以下是这些目标的示例图：

<table>
  <tr>
    <td><b>Compacts</b></td>
    <td><img alt="Compacts_1" src="./resources/sub_class/Compacts/1.png"></td>
    <td><img alt="Compacts_1" src="./resources/sub_class/Compacts/2.png"></td>
    <td><img alt="Compacts_1" src="./resources/sub_class/Compacts/3.png"></td>
    <td><img alt="Compacts_1" src="./resources/sub_class/Compacts/4.png"></td>
    <td><img alt="Compacts_1" src="./resources/sub_class/Compacts/5.png"></td>
  </tr>
  <tr>
    <td><b>Sedans</b></td>
    <td><img alt="Sedans_1" src="./resources/sub_class/Sedans/1.png"></td>
    <td><img alt="Sedans_1" src="./resources/sub_class/Sedans/2.png"></td>
    <td><img alt="Sedans_1" src="./resources/sub_class/Sedans/3.png"></td>
    <td><img alt="Sedans_1" src="./resources/sub_class/Sedans/4.png"></td>
    <td><img alt="Sedans_1" src="./resources/sub_class/Sedans/5.png"></td>
  </tr>
  <tr>
    <td><b>SUVs</b></td>
    <td><img alt="SUVs_1" src="./resources/sub_class/SUVs/1.png"></td>
    <td><img alt="SUVs_1" src="./resources/sub_class/SUVs/2.png"></td>
    <td><img alt="SUVs_1" src="./resources/sub_class/SUVs/3.png"></td>
    <td><img alt="SUVs_1" src="./resources/sub_class/SUVs/4.png"></td>
    <td><img alt="SUVs_1" src="./resources/sub_class/SUVs/5.png"></td>
  </tr>
  <tr>
    <td><b>Coupes</b></td>
    <td><img alt="Coupes_1" src="./resources/sub_class/Coupes/1.png"></td>
    <td><img alt="Coupes_1" src="./resources/sub_class/Coupes/2.png"></td>
    <td><img alt="Coupes_1" src="./resources/sub_class/Coupes/3.png"></td>
    <td><img alt="Coupes_1" src="./resources/sub_class/Coupes/4.png"></td>
    <td><img alt="Coupes_1" src="./resources/sub_class/Coupes/5.png"></td>
  </tr>
  <tr>
    <td><b>Muscle</b></td>
    <td><img alt="Muscle_1" src="./resources/sub_class/Muscle/1.png"></td>
    <td><img alt="Muscle_1" src="./resources/sub_class/Muscle/2.png"></td>
    <td><img alt="Muscle_1" src="./resources/sub_class/Muscle/3.png"></td>
    <td><img alt="Muscle_1" src="./resources/sub_class/Muscle/4.png"></td>
    <td><img alt="Muscle_1" src="./resources/sub_class/Muscle/5.png"></td>
  </tr>
  <tr>
    <td><b>SportsClassics</b></td>
    <td><img alt="SportsClassics_1" src="./resources/sub_class/SportsClassics/1.png"></td>
    <td><img alt="SportsClassics_1" src="./resources/sub_class/SportsClassics/2.png"></td>
    <td><img alt="SportsClassics_1" src="./resources/sub_class/SportsClassics/3.png"></td>
    <td><img alt="SportsClassics_1" src="./resources/sub_class/SportsClassics/4.png"></td>
    <td><img alt="SportsClassics_1" src="./resources/sub_class/SportsClassics/5.png"></td>
  </tr>
  <tr>
    <td><b>Sports</b></td>
    <td><img alt="Sports_1" src="./resources/sub_class/Sports/1.png"></td>
    <td><img alt="Sports_1" src="./resources/sub_class/Sports/2.png"></td>
    <td><img alt="Sports_1" src="./resources/sub_class/Sports/3.png"></td>
    <td><img alt="Sports_1" src="./resources/sub_class/Sports/4.png"></td>
    <td><img alt="Sports_1" src="./resources/sub_class/Sports/5.png"></td>
  </tr>
  <tr>
    <td><b>Super</b></td>
    <td><img alt="Super_1" src="./resources/sub_class/Super/1.png"></td>
    <td><img alt="Super_1" src="./resources/sub_class/Super/2.png"></td>
    <td><img alt="Super_1" src="./resources/sub_class/Super/3.png"></td>
    <td><img alt="Super_1" src="./resources/sub_class/Super/4.png"></td>
    <td><img alt="Super_1" src="./resources/sub_class/Super/5.png"></td>
  </tr>
  <tr>
    <td><b>OffRoad</b></td>
    <td><img alt="OffRoad_1" src="./resources/sub_class/OffRoad/1.png"></td>
    <td><img alt="OffRoad_1" src="./resources/sub_class/OffRoad/2.png"></td>
    <td><img alt="OffRoad_1" src="./resources/sub_class/OffRoad/3.png"></td>
    <td><img alt="OffRoad_1" src="./resources/sub_class/OffRoad/4.png"></td>
    <td><img alt="OffRoad_1" src="./resources/sub_class/OffRoad/5.png"></td>
  </tr>
  <tr>
    <td><b>Industrial</b></td>
    <td><img alt="Industrial_1" src="./resources/sub_class/Industrial/1.png"></td>
    <td><img alt="Industrial_1" src="./resources/sub_class/Industrial/2.png"></td>
    <td><img alt="Industrial_1" src="./resources/sub_class/Industrial/3.png"></td>
    <td><img alt="Industrial_1" src="./resources/sub_class/Industrial/4.png"></td>
    <td><img alt="Industrial_1" src="./resources/sub_class/Industrial/5.png"></td>
  </tr>
  <tr>
    <td><b>Utility</b></td>
    <td><img alt="Utility_1" src="./resources/sub_class/Utility/1.png"></td>
    <td><img alt="Utility_1" src="./resources/sub_class/Utility/2.png"></td>
    <td><img alt="Utility_1" src="./resources/sub_class/Utility/3.png"></td>
    <td><img alt="Utility_1" src="./resources/sub_class/Utility/4.png"></td>
    <td><img alt="Utility_1" src="./resources/sub_class/Utility/5.png"></td>
  </tr>
  <tr>
    <td><b>Vans</b></td>
    <td><img alt="Vans_1" src="./resources/sub_class/Vans/1.png"></td>
    <td><img alt="Vans_1" src="./resources/sub_class/Vans/2.png"></td>
    <td><img alt="Vans_1" src="./resources/sub_class/Vans/3.png"></td>
    <td><img alt="Vans_1" src="./resources/sub_class/Vans/4.png"></td>
    <td><img alt="Vans_1" src="./resources/sub_class/Vans/5.png"></td>
  </tr>
  <tr>
    <td><b>Service</b></td>
    <td><img alt="Service_1" src="./resources/sub_class/Service/1.png"></td>
    <td><img alt="Service_1" src="./resources/sub_class/Service/2.png"></td>
    <td><img alt="Service_1" src="./resources/sub_class/Service/3.png"></td>
    <td><img alt="Service_1" src="./resources/sub_class/Service/4.png"></td>
    <td><img alt="Service_1" src="./resources/sub_class/Service/5.png"></td>
  </tr>
  <tr>
    <td><b>Emergency</b></td>
    <td><img alt="Emergency_1" src="./resources/sub_class/Emergency/1.png"></td>
    <td><img alt="Emergency_1" src="./resources/sub_class/Emergency/2.png"></td>
    <td><img alt="Emergency_1" src="./resources/sub_class/Emergency/3.png"></td>
    <td><img alt="Emergency_1" src="./resources/sub_class/Emergency/4.png"></td>
    <td><img alt="Emergency_1" src="./resources/sub_class/Emergency/5.png"></td>
  </tr>
  <tr>
    <td><b>Commercial</b></td>
    <td><img alt="Commercial_1" src="./resources/sub_class/Commercial/1.png"></td>
    <td><img alt="Commercial_1" src="./resources/sub_class/Commercial/2.png"></td>
    <td><img alt="Commercial_1" src="./resources/sub_class/Commercial/3.png"></td>
    <td><img alt="Commercial_1" src="./resources/sub_class/Commercial/4.png"></td>
    <td><img alt="Commercial_1" src="./resources/sub_class/Commercial/5.png"></td>
  </tr>
</table>


### 标签

每张图像对应一个标签文件，以下是一个标签的示例。第一行为图像的宽和高，第二行为相机的位姿信息，前三个X、Y、Z和后三个X、Y、Z分别代表相机在游戏世界的坐标和三个方向角。第三行起的每一行都代表一个目标，分别是目标的序号，包围盒左上角和右下角的横纵坐标，车辆类别，车辆尺寸，以及目标质量。

```text
2048,1152
X:-420.2515 Y:-2069.219 Z:144.7112,X:-89.97202 Y:-70.18397 Z:0
0,1120,255,1149,331,Sedans,small-vehicle,High
1,1100,732,1126,796,Sedans,small-vehicle,High
2,3,701,92,801,Commercial,large-vehicle,High
...
```

## 引用

如果你想使用GTAVDataCollection工具或者GTA5-Vehicle数据集，请引用下面的文章：

```text

```

<p align="center">💻 <a href="https://github.com/lsq210/GTAVDataCollection" target="_blank">项目地址</a> | 📬 <a href="mailto:luoshiqi@whu.edu.cn">联系我</a></p>
