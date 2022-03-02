# MocapForAll Receiver Plugin for Unity
 
 Unity sample project to receive data from MocapForAll

## Environment

- Windows 10 64bit
- Unity
  - 2019.4.36f1
  - 2020.3.30f1
  - 2021.2.13f1
 
## How to use

### Settings in MocapForAll

- turn on "Settings > Data export > VMT protocol > Send tracking points"
- turn off "Settings > Data export > VMT protocol > Send tracking points> As relative position to HMD"
- turn on "Settings > Data export > VMT protocol > Send tracking points> Tracking points to be sent"
- turn on "Settings > General > Capture hand" if you want to capture finger movements.
- enter the same IP address as the receiver plugin in "Settings > Data export > destination IP address for VMT and VMC"
- enter the same port as the receiver plugin in "Settings > Data export > VMT protocol > Send tracking points"

![image](https://user-images.githubusercontent.com/89242761/156302356-58056f74-80a9-4278-b01c-f0512cbcd4f4.png)

### Unity

- Open project
- Open /Assets/VmtReceiver/VmtReceiverSampleScene.unity
- Click play

## Third party license notice

This repository uses the following open source software:

- [uOSC](https://github.com/hecomi/uOSC) created by hecomi
