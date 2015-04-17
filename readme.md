HIDIRT
======

HIDIRT is an acronym for HID InfraRed Transceiver.

Being an USB HID device, it doesn't need any driver installation but only some dlls and an executable or a MediaPortal plugin to run on Windows PCs.

It allows users to receive and/ or transmit infrared commands with many different IR protocols. Received IR commands can be used to initiate a single key press or a whole sequence of keys that is sent to the application in the foreground. It's also possible to launch an application and pass arguments to that application. Received commands can be automatically forwarded to other devices. A custom IR transmission can be easily started by launching the executable with the corresponding argument. Therefore other devices can be controlled via Windows.

The first command that is received, will be stored inside the device and acts as power-up/ power-down command for the host. So when this command is being received again, the device starts the host PC, either via USB or the power button (if connected) or it initiates a shutdown via power button. It's also possible to define a command that resets the PC via the reset button if it's received 3 times in a row. These functions do not need the host application running.

The HID device features a real time clock that allows to start the PC at a given time. This time can also be configured by passing the corresponding argument to the application. If the PCs RTC is inaccurate it's possible to sync it with the device clock and vice versa.

The host project consists of a couple of sub-projects:
- hidirt.MePo   - MediaPortal plugin to communicate with the HID device and automatically update the wakeup time.
- hidirt.exe    - standalone application to communicate with the HID device. Offers a graphical mode when executed without parameters and a simple console mode when executed with parameters.
- hidirt.common - common features and functionality of the standalone application (HIDIRT.exe) and the MediaPortal plugin (HIDIRT.MePo).

Requirements
------------
- .NET 4.0 framework
- GenericHid v0.1