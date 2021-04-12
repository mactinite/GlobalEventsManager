# Global Events Manager
## About
An event manager for unity. Based on the ["Create a simple messaging system with Events" Tutorial on Unity Learn](https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events) 
## Installation

To install the latest version of this package copy this url and add it using [the package manager UI](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.1/manual/index.html):

`https://github.com/mactinite/UnityToolboxCommons.git#main`

Or add the following dependency to your manifest.json file
```json
{
    "dependencies": {
        "com.mactinite.extensibledamagesystem": "https://github.com/mactinite/UnityToolboxCommons.git#main"
    }
}
```

## Overview

The Global Events Manager(GEM) at it's core is a single component that provides a static reference to an API to **Trigger** and **Listen** to **Events**. 

The package also provides two basic components that allow you to utilise the system with no or minimal code. These components use ScriptableObjects to represent Events called Global Event Assets. 

### Create a new Global Event
to create a new Global Event Asset, right click in the project tab and select Create > GlobalEventsManager > New Global Event
![image](https://user-images.githubusercontent.com/4845476/114330825-6bbbc700-9af7-11eb-9d3f-fe2e69eb80e3.png)

### Listen To Global Event Component
This will listen for a global event and fire a Unity Event which can be handled by built in unity components or custom components.
Optionally you can configure a header to be extracted and passed as a dynamic parameter to the Unity Event. This can be useful for centralized spawn managers or updating UI.

### Trigger Global Event Component
This compoonent provides a public method to trigger a Global Event. The only header attached is the "Position" header containing its world position.
