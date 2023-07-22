# GTAVDataCollection

GTAVDataCollection is a mod to extract synthetic data from Grand Theft Auto V.  The data includes  photo-realistic computer images and annotations that can be used for the training of machine learning algorithms.

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
| **Compacts**| ![Compacts_1](resources/sub_class/Compacts/1.png)  | ![Compacts_2](resources/sub_class/Compacts/2.png) | ![Compacts_3](resources/sub_class/Compacts/3.png)  | ![Compacts_4](resources/sub_class/Compacts/4.png) | ![Compacts_5](resources/sub_class/Compacts/5.png)  |
|  ----  | ----  | ---- | ----  | ---- | ---- |
| **Sedans** | ![Sedans_1](resources/sub_class/Sedans/1.png)  | ![Sedans_2](resources/sub_class/Sedans/2.png) | ![Sedans_3](resources/sub_class/Sedans/3.png)  | ![Sedans_4](resources/sub_class/Sedans/4.png) |![Sedans_5](resources/sub_class/Sedans/5.png)  |
| **SUVs** | ![SUVs_1](resources/sub_class/SUVs/1.png)  | ![SUVs_2](resources/sub_class/SUVs/2.png) | ![SUVs_3](resources/sub_class/SUVs/3.png)  | ![SUVs_4](resources/sub_class/SUVs/4.png) |![SUVs_5](resources/sub_class/SUVs/5.png)  |
| **Coupes** | ![Coupes_1](resources/sub_class/Coupes/1.png)  | ![Coupes_2](resources/sub_class/Coupes/2.png) | ![Coupes_3](resources/sub_class/Coupes/3.png)  | ![Coupes_4](resources/sub_class/Coupes/4.png) |![Coupes_5](resources/sub_class/Coupes/5.png)  |
| **Muscle** | ![Muscle_1](resources/sub_class/Muscle/1.png)  | ![Muscle_2](resources/sub_class/Muscle/2.png) | ![Muscle_3](resources/sub_class/Muscle/3.png)  | ![Muscle_4](resources/sub_class/Muscle/4.png) |![Muscle_5](resources/sub_class/Muscle/5.png)  |
| **SportsClassics** | ![SportsClassics_1](resources/sub_class/SportsClassics/1.png)  | ![SportsClassics_2](resources/sub_class/SportsClassics/2.png) | ![SportsClassics_3](resources/sub_class/SportsClassics/3.png)  | ![SportsClassics_4](resources/sub_class/SportsClassics/4.png) |![SportsClassics_5](resources/sub_class/SportsClassics/5.png)  |
| **Sports** | ![Sports_1](resources/sub_class/Sports/1.png)  | ![Sports_2](resources/sub_class/Sports/2.png) | ![Sports_3](resources/sub_class/Sports/3.png)  | ![Sports_4](resources/sub_class/Sports/4.png) |![Sports_5](resources/sub_class/Sports/5.png)  |
| **Super** | ![Super_1](resources/sub_class/Super/1.png)  | ![Super_2](resources/sub_class/Super/2.png) | ![Super_3](resources/sub_class/Super/3.png)  | ![Super_4](resources/sub_class/Super/4.png) |![Super_5](resources/sub_class/Super/5.png)  |
| **OffRoad** | ![OffRoad_1](resources/sub_class/OffRoad/1.png)  | ![OffRoad_2](resources/sub_class/OffRoad/2.png) | ![OffRoad_3](resources/sub_class/OffRoad/3.png)  | ![OffRoad_4](resources/sub_class/OffRoad/4.png) |![OffRoad_5](resources/sub_class/OffRoad/5.png)  |
| **Industrial** | ![Industrial_1](resources/sub_class/Industrial/1.png)  | ![Industrial_2](resources/sub_class/Industrial/2.png) | ![Industrial_3](resources/sub_class/Industrial/3.png)  | ![Industrial_4](resources/sub_class/Industrial/4.png) |![Industrial_5](resources/sub_class/Industrial/5.png)  |
| **Utility** | ![Utility_1](resources/sub_class/Utility/1.png)  | ![Utility_2](resources/sub_class/Utility/2.png) | ![Utility_3](resources/sub_class/Utility/3.png)  | ![Utility_4](resources/sub_class/Utility/4.png) |![Utility_5](resources/sub_class/Utility/5.png)  |
| **Vans** | ![Vans_1](resources/sub_class/Vans/1.png)  | ![Vans_2](resources/sub_class/Vans/2.png) | ![Vans_3](resources/sub_class/Vans/3.png)  | ![Vans_4](resources/sub_class/Vans/4.png) |![Vans_5](resources/sub_class/Vans/5.png)  |
| **Service** | ![Service_1](resources/sub_class/Service/1.png)  | ![Service_2](resources/sub_class/Service/2.png) | ![Service_3](resources/sub_class/Service/3.png)  | ![Service_4](resources/sub_class/Service/4.png) |![Service_5](resources/sub_class/Service/5.png)  |
| **Emergency** | ![Emergency_1](resources/sub_class/Emergency/1.png)  | ![Emergency_2](resources/sub_class/Emergency/2.png) | ![Emergency_3](resources/sub_class/Emergency/3.png)  | ![Emergency_4](resources/sub_class/Emergency/4.png) |![Emergency_5](resources/sub_class/Emergency/5.png)  |
| **Commercial** | ![Commercial_1](resources/sub_class/Commercial/1.png)  | ![Commercial_2](resources/sub_class/Commercial/2.png) | ![Commercial_3](resources/sub_class/Commercial/3.png)  | ![Commercial_4](resources/sub_class/Commercial/4.png) |![Commercial_5](resources/sub_class/Commercial/5.png)  |
---

### Label Format

Each image has a corresponding label file. Here’s an example of a label structure: The first line contains the image’s dimensions. The second line provides camera pose information, including position and orientation. From the third line onwards, each line represents a target with its index, bounding box coordinates, vehicle category, size, and quality

```text
2048,1152
X:-241.8259 Y:-2115.118 Z:150.1783,X:-89.97202 Y:-22.32331 Z:0
0,288,245,359,310,Muscle,small-vehicle,High
1,699,683,768,737,Sports,small-vehicle,High
...
```

## Citation

If you make use of the GTAVDataCollection or GTA5-Vehicle dataset, please cite our following paper

```text

```

<p align="center">💻 <a href="https://github.com/lsq210/GTAVDataCollection" target="_blank">项目地址</a> | 📬 <a href="mailto:luoshiqi@whu.edu.cn">联系我</a></p>
