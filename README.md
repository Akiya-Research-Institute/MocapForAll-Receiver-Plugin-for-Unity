# MocapForAll Receiver Plugin for Unity
 
 Unity sample project to receive data from MocapForAll

## Environment

- Windows 10 64bit
- Unity 2019.4.36f1
 
## How to use

### Settings in MocapForAll

In MocapForAll,
- turn on "Settings > Data export > VMT protocol > Send tracking points"
- turn off "Settings > Data export > VMT protocol > Send tracking points> As relative position to HMD"
- turn on "Settings > Data export > VMT protocol > Send tracking points> Tracking points to be sent"
- turn on "Settings > General > Capture hand" if you want to capture finger movements.
- enter the same IP address as the receiver plugin in "Settings > Data export > destination IP address for VMT and VMC"
- enter the same port as the receiver plugin in "Settings > Data export > VMT protocol > Send tracking points"

### Unity

- Open project
- Open /Assets/VmtReceiver/VmtReceiverSampleScene.unity
- Click play