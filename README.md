# Accelerometer-Controlled-Airplane-Game-Unity

This project demonstrates how to create an airplane controller using cardboard and an ADXL 345 accelerometer sensor. The sensor values are converted to pitch, roll, and yaw, which are then transmitted to Unity using serial communication protocol to control the orientation of the game object.

# Getting Started
Prerequisites
To run this project, you will need:

An ADXL 345 accelerometer sensor

An Arduino board

A computer running Unity

A cardboard or similar material for creating the airplane controller

#Installing
Clone this repository to your local machine.

Connect the ADXL 345 sensor to your Arduino board.

Upload the adxl345.ino sketch to your Arduino board.

Connect your Arduino board to your computer and open the Arduino IDE.

Open the serial monitor and note the baud rate (e.g. 9600).

Open the Unity project in Unity.

Open the SerialController.cs script in Unity and change the portName and baudRate variables to match your Arduino board settings.

Attach the airplane controller to your computer.

Run the Unity project.

#Usage
Tilt the airplane controller to control the pitch, roll, and yaw of the game object.

#Video Demonstration
