# Medialogy 10th Semester Thesis

> Educational game made in Unity using C#

	Due on May 26th, 2016
	[Frederik Vanggaard](https://github.com/drudoo) & [Andrea Keiser](https://github.com/dedepi) 

# Installation
The appliation is written for Android tablets and tested on the Nexus 7 (2013) and the Nexus 9. 
The application does not require any specific libraries or additional support from outside of Unity.
Ever scene in the Scenes folder except for ``Game_fred`` should be added to the build settings. 

## Bugs

- UniqueID is the current date, so working on a quiz at mightnight can *potentially* cause problems.
- Enter game name is not native to android. Fix later.
- Enemies walk between obstacles and not between waypoints.
- You can dismiss questions on android. 

## Build wirelessly to Android (Mac)

- Install ``adb``:


	brew install android-platform-tools


Plug in device:

    adb tcpip 5555

Unplug device

    adb connect deviceIP

Build and Run normally from Unity.

## Get Debug.Log() from Android (Mac)

- Using ``adb``:


	adb logcat
    
   
- Only get current app data

	db logcat | grep `adb shell ps | grep com.drudoo.med10 | cut -c10-15`


# License

The MIT License (MIT)

Copyright (c) 2016 Frederik Vanggaard

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.