# Connecting Raspberry Pi with a Remote Computer

## 1. Connecting via VNC
Virtual Network Computing (VNC) allows you to access the Raspberry Pi’s graphical interface remotely.

### Enabling VNC on Raspberry Pi
1. Open a terminal and run:
```
sudo raspi-config
```
2. Go to **Interfacing Options > VNC** and enable it.
3. Install VNC Server (if not already installed):
```
sudo apt update
sudo apt install realvnc-vnc-server
```

### Connecting from Another Computer

1. Download and Install VNC Viewer:
- From [RealVNC](https://www.realvnc.com/en/connect/download/viewer/)

2. Connect to Raspberry Pi:
- Open VNC Viewer and create a new connection
- Log in with your Raspberry Pi username and password


## 2. Connecting via TeamViewer
TeamViewer is a cross-platform remote desktop application.

### Installing TeamViewer on Raspberry Pi
1. Download TeamViewer Host for Raspberry Pi:
```
wget https://download.teamviewer.com/download/linux/teamviewer-host_armhf.deb
```
2. Install TeamViewer:
```
sudo dpkg -i teamviewer-host_armhf.deb
sudo apt --fix-broken install
```
3. Start TeamViewer and accept the EULA:
```
sudo teamviewer setup
```
4. Get your TeamViewer ID:
```
teamviewer info
```

### Connecting from Another Computer
1. Install TeamViewer on your computer from [here](https://www.teamviewer.com/en-us/download/windows-at/?alloy_redirect=eyJ2IjoxLCJhZCI6IjExNTA0MTM6MDowfDIsMTE1MDQxMzowOjB8MSwxMTM3OTY1OjA6MHwyLDExMzc5NjU6MDowfDEsMTE2Mjc2NjoxOjB8MCwxMTYyNzY2OjE6MHwyLDExNjI3NjY6MTowfDEsMTE0MjkyMDowOjB8MiwxMTQyOTIwOjA6MHwxIn0%3D).
2. Open TeamViewer and enter the Raspberry Pi’s TeamViewer ID.
3. Click Connect and enter the Raspberry Pi’s password.


## 3. Connecting via SSH
Secure Shell (SSH) allows you to remotely control your Raspberry Pi from another computer.

### Enabling SSH on Raspberry Pi
1. Open a terminal on your Raspberry Pi and run:
   ```
   sudo raspi-config
   ```
2. Navigate to **Interfacing Options > SSH** and enable it.
3. Find your Raspberry Pi's IP address by running:
   ```
   hostname -I
   ```

### Connecting from Another Computer
1. Linux/Mac: Open a terminal and run:
   ```
   ssh pi@<Raspberry_Pi_IP>
   ```
2. Windows: Use MobaXterm or PuTTY :
- Download and install [MobaXterm](https://mobaxterm.mobatek.net/) or [PuTTY](https://www.putty.org/).
- Enter your Raspberry Pi's IP address and select SSH.
- Click Open and log in with pi as username and your password.


