# GTAVDataCollection

[GTAVDataCollection](https://github.com/lsq210/GTAVDataCollection/) is a mod to extract synthetic data from Grand Theft Auto V.  The data includes  photo-realistic computer images and annotations that can be used for the training of machine learning algorithms.

![demo image](resources/bbox.jpg)

English | [简体中文](./README-zh_CN.md)

## 🛠️ Requirements

- [ScriptHookV](http://www.dev-c.com/gtav/scripthookv/)
- [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet/releases)
- [Scripted Camera Tool](https://www.gta5-mods.com/scripts/scripted-camera-tool-1-0)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs)
- [.NET Framework ≥ 4.8](https://www.visualstudio.com/cs/downloads/)
- Others managed by Nuget

## 🚀 Quick Start

1. Download and install ScriptHookV、ScriptHookVDotNet and Scripted Camera Tool.
2. Download [pre-built binaries](https://github.com/lsq210/GTAVDataCollection/releases/) and copy them to `Grand Theft Auto V/scripts/`.
3. Start the game.
4. Press T to set the camera.
5. Press Y to start or stop extracting data. The data should be created in `Grand Theft Auto V/data/`.

## 💿 Dataset

### Download

A large-scale remote sensing image dataset for vehicle object detection called GTA5-Vehicle has been built based on GTAVDataCollection.
Please also note that the data is for research and educational use only.

[Baidu Netdisk](https://pan.baidu.com/s/1ad8-_92C9RGL2wQpRCAjGA?pwd=8ply)

### Object Category

The dataset includes 15 vehicle object classes: Compacts, Sedans, SUVs, Coupes, Muscle, SportsClassics, Sports, Super, OffRoad, Industrial, Utility, Vans, Service, Emergency, and Commercial. Here are some example images of these objects:

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


### Label Format

Each image has a corresponding label file. Here’s an example of a label structure: The first line contains the image’s dimensions. The second line provides camera pose information, including position and orientation. From the third line onwards, each line represents a target with its index, bounding box coordinates, vehicle category, size, and quality

```text
2048,1152
X:-420.2515 Y:-2069.219 Z:144.7112,X:-89.97202 Y:-70.18397 Z:0
0,1120,255,1149,331,Sedans,small-vehicle,High
1,1100,732,1126,796,Sedans,small-vehicle,High
2,3,701,92,801,Commercial,large-vehicle,High
...
```

## Citation

If you make use of the GTAVDataCollection or GTA5-Vehicle dataset, please cite our following paper

```text

```

<p align="center">💻 <a href="https://github.com/lsq210/GTAVDataCollection" target="_blank">项目地址</a> | 📬 <a href="mailto:luoshiqi@whu.edu.cn">联系我</a></p>
