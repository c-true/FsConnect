# FsConnect

A simple easy-to-use wrapper for the Flight Simulator 2020 SimConnect library. A simple solution to simple problems, if you already are fluent in SimConnect, this won't impress you much.
If, on the other hand, you just want to connect to Flight Simulator and read some information this may give you a quicker start.

FsConnect uses the _Microsoft.FlightSimulator.SimConnect_ .NET Framework library and the underlying native x64 _simconnect.dll_ library. 
These files are distributed via the Flight Simulator 2020 SDK, currently version 0.10.0, but are included for easy use.

At the moment this project is intended as an easier to use wrapper than the current SimConnect for simple projects, creating a simpler C# programming model and reducing the need for repeated boiler plate code. 

> NOTE: **Expect breaking changes and infrequent updates.**

## Additional information

For more information about SimConnect and the Flight Simulator SDK see the [Microsoft Flight Simulator SDK site](
https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/SimConnect_SDK.htm) and the [SimConnect SDK section](https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/SimConnect_SDK.htm) in particular.

## Current features

* Supports connections from API, without direct use of SimConnect.cfg file
* Supports registering and requesting simple simulation variables, including by reflection.
* Supports updating simulation variables.
* Supports enums for known SimVars, units and events.
* Does not require a Windows message pump.
* NuGet package handles deployment of native binaries, just add reference to the package.

## Roadmap

* Development of the FsConnect libary is first and foremost to have fun and create simple utilities and to better understand the posibilities of interfacing with Microsoft Flight Simulator.
* FsConnect should provide a better developer experience than both the native SimConnect and the managed Microsoft.FlightSimulator.SimConnect. This may hide important features in these APIs, so please raise an issue in such cases.
* FsConnect should hopefully be better documented as a starting point for new developers.

More specific:

* Establish parity on the most important SimConnect API features.
* Work with hiding the 'ugly' details of defining data definitions, through mechanisms such as reflection.
* Investigate if a purely .NET Core/5 version is possible

## Getting started

* Download the Flight Simulator SDK.
* See the list of available simulation variables in the SDK documentation: Documentation/04-Developer_Tools/SimConnect/SimConnect_Status_of_Simulation_Variables.html
* Determine unit to use when registering the data structure.
* Build a C# struct to hold data data definition. (See example below)
* Define a data definition and register it. (See example below)
* Take a look at the Simvars sample project and example below.

## Packages and distribution

Releases from this repo is distributed using NuGet:

### CTrue.FsConnect

[![NuGet](https://img.shields.io/nuget/v/CTrue.FsConnect.svg)](https://www.nuget.org/packages/CTrue.FsConnect) [![Package stats FsConnect](https://img.shields.io/nuget/dt/CTrue.FsConnect.svg)](https://www.nuget.org/packages/CTrue.FsConnect)

### CTrue.FsConnect.Managers

[![NuGet](https://img.shields.io/nuget/v/CTrue.FsConnect.Managers.svg)](https://www.nuget.org/packages/CTrue.FsConnect.Managers) [![Package stats FsConnect.Managers](https://img.shields.io/nuget/dt/CTrue.FsConnect.Managers.svg)](https://www.nuget.org/packages/CTrue.FsConnect.Managers)

## Defining data definitions

To request information from Flight Simulator using FsConnect objects needs to be constructued in a certain way.

Such an object must:

* Be a struct
* Be attributed with: [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]

## SimConnect simulator variables and data definition

SimConnect uses simulation variables or SimVars to get available information from MSFS. Read more about SimVars in the [SimVars SDK documentation](https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Simulation_Variables.htm).

### Struct

The SimVars are stored in a struct when retrieved from MSFS. The struct combines a set of SimVars into a type that can be used to be filled by a request to MSFS.  

Create a struct similar to shown below to hold this information:
```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct MySimVarsStruct
{
    ...
}
```

### SimVar Names

An potentially incomplete list of valid names for SimVars can be looked up in the SDK documentation.

### SimVar types

Any string members needs the attribute [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] with the SizeConst set to the expected size of the string.

### SimVar units

See the documentation for [simulation variables](https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Simulation_Variables.htm) to determine the correct data type.

Before Flight Simulator can use this structure it needs the definition of the object. Flight Simulator sees a definition as a list of properties, with specified units and data types. This definition is then used to fill the registred struct with data from Flight Simulator.

```csharp
List<SimVar> definition = new List<SimVar>();

// Consult the SDK for valid sim variable names, units and whether they can be written to.
definition.Add(new SimVar("Title", null, SIMCONNECT_DATATYPE.STRING256));
definition.Add(new SimVar("Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));
definition.Add(new SimVar("Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64));

fsConnect.RegisterDataDefinition<PlaneInfoResponse>(Definitions.PlaneInfo, definition);
```

See the enums FsSimVar and FsUnit in the FsConnect library for simpler to use enums instead of strings for specifying variable name and units.
This would be an equal definition:

```csharp
definition.Add(new SimVar(FsSimVar.Title, FsUnit.None, SIMCONNECT_DATATYPE.STRING256));
definition.Add(new SimVar(FsSimVar.PlaneLatitude, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
definition.Add(new SimVar(FsSimVar.PlaneLongitude, FsUnit.Radians, SIMCONNECT_DATATYPE.FLOAT64));
```

### Reflection based data definition

An alternative method of defining the data definition is to decorate the type with the SimVar attribute to describe field names and units:

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct PlaneInfo
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public String Title;
    [SimVar(UnitId = FsUnit.Degree)]
    public double PlaneLatitude;
    [SimVar(NameId=FsSimVar.PlaneLongitude, UnitId = FsUnit.Degree)]
    public double Longitude;
}
```

Such a type can be easily registered using FsConnect by just providing the type. An enum based defintion id can be supplied or let FsConnect generate one. The request id can similarily also be an int.

```csharp

int myRequestId = 42;
int myDefineId = fsConnect.RegisterDataDefinition<MyDataDefinitionStruct>();
fsConnect.RequestData(myRequestId, myDefineId);

```

### Generating definition ids

FsConnect supports generating definition ids that can be stored by the client as an int, elliminating the need to managing enums and ranges of their ids. FsConnect will manage an internal enum and range of ints.


```csharp

int planeInfoDefinitionId = fsConnect.RegisterDataDefinition<PlaneInfo>();
fsConnect.

```

## Client events

Client events can be mapped to sim events, either by using the event name or the FsEventNameId enum to identify the event.

See below for an example on how to set the time in Flight Simulator using client events. The WorldManager class in the CTrue.FsConnect.Managers project also contains an example on this.

```csharp

enum MyEnums
{
    SetTimeGroup,
    SetZuluYears,
    SetZuluDays,
    SetZuluHours,
    SetZuluMinute,
};

fsConnect.MapClientEventToSimEvent(MyEnums.SetTimeGroup, MyEnums.SetZuluYears, FsEventNameId.ZuluYearSet);
fsConnect.MapClientEventToSimEvent(MyEnums.SetTimeGroup, MyEnums.SetZuluDays, FsEventNameId.ZuluDaySet);
fsConnect.MapClientEventToSimEvent(MyEnums.SetTimeGroup, MyEnums.SetZuluHours, FsEventNameId.ZuluHoursSet);
fsConnect.MapClientEventToSimEvent(MyEnums.SetTimeGroup, MyEnums.SetZuluMinute, FsEventNameId.ZuluMinutesSet);

fsConnect.SetNotificationGroupPriority(MyEnums.SetTimeGroup);

DateTime now = DateTime.Now();
fsConnect.TransmitClientEvent(MyEnums.SetZuluYears, (uint)time.Year, SetTimeGroup.SetTime);
fsConnect.TransmitClientEvent(MyEnums.SetZuluDays, (uint)time.DayOfYear, SetTimeGroup.SetTime);
fsConnect.TransmitClientEvent(MyEnums.SetZuluHours, (uint)time.Hour, SetTimeGroup.SetTime);
fsConnect.TransmitClientEvent(MyEnums.SetZuluMinute, (uint)time.Minute, SetTimeGroup.SetTime);
```

## Example

1) Create a .NET Framework Console project that target x64.
2) Add a reference to the CTrue.FsConnect package.
3) Set up Flight Simulator to receive remote TCP connections, see the SimConnect.xml file, and configure the example accordingly.

Ensure that the SimConnect.xml file has an entry for the type of connection that you want to establish.
E.g. for a remote TCP IvP4 connection, the file should have an entry such as this:

```xml
    <SimConnect.Comm>
        <Descr>Static IP4 port</Descr>
        <Protocol>IPv4</Protocol>
        <Scope>remote</Scope>
        <Port>33333</Port>
        <MaxClients>64</MaxClients>
        <MaxRecvSize>41088</MaxRecvSize>
    </SimConnect.Comm>
```

For a local TCP IPv4 connection:

```xml
    <SimConnect.Comm>
        <Descr>Static IP4 port</Descr>
        <Protocol>IPv4</Protocol>
        <Scope>local</Scope>
        <Port>500</Port>
        <MaxClients>64</MaxClients>
        <MaxRecvSize>41088</MaxRecvSize>
    </SimConnect.Comm>
```

The SimConnect.xml can be found in the "%AppData%\Microsoft Flight Simulator" folder.

4) See example below, or the CTrue.FsConnect.ExampleConsole project in the GitHub repo:

```csharp
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CTrue.FsConnect;
using Microsoft.FlightSimulator.SimConnect;

namespace FsConnectTest
{
    public enum Requests
    {
        PlaneInfoRequest = 0
    }

    // Use field name and SimVar attribute to configure the data definition for the type.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlaneInfoResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        [SimVar(UnitId = FsUnit.Degree)]
        public double PlaneLatitude;
        [SimVar(UnitId = FsUnit.Degree)]
        public double PlaneLongitude;
        [SimVar(UnitId = FsUnit.Feet)]
        public double PlaneAltitude;
        [SimVar(UnitId = FsUnit.Degree)]
        public double PlaneHeadingDegreesTrue;
        [SimVar(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.MeterPerSecond)]
        public double AirspeedTrueInMeterPerSecond;
        [SimVar(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.Knot)]
        public double AirspeedTrueInKnot;
    }

    public class FsConnectTestConsole
    {
        public static void Main(string[] args)
        {
            string hostName = "localhost";
            uint port = 500;

            // Also supports "somehostname 1234"
            if(args.Length == 2)
            {
                hostName = args[0];
                port = uint.Parse(args[1]);
            }

            FsConnect fsConnect = new FsConnect();

            // Specify where the SimConnect.cfg should be written to
            fsConnect.SimConnectFileLocation = SimConnectFileLocation.Local;

            // Creates a SimConnect.cfg and connect to Flight Simulator using this configuration.
            fsConnect.Connect("TestApp", hostName, port, SimConnectProtocol.Ipv4);

            // Other alternatives, use existing SimConfig.cfg and specify config index:
            // fsConnect.Connect(1);
            // or
            // fsConnect.Connect();

            fsConnect.FsDataReceived += HandleReceivedFsData;

            // Consult the SDK for valid sim variable names, units and whether they can be written to.
            int planeInfoDefinitionId = fsConnect.RegisterDataDefinition<PlaneInfoResponse>();

            ConsoleKeyInfo cki;

            do
            {
                fsConnect.RequestData(Requests.PlaneInfoRequest, planeInfoDefinitionId);
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);

            fsConnect.Disconnect();
        }

        private static void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            if (e.RequestId == (uint)Requests.PlaneInfoRequest)
            {
                PlaneInfoResponse r = (PlaneInfoResponse)e.Data.FirstOrDefault();
                Console.WriteLine($"{r.PlaneLatitude:F4} {r.PlaneLongitude:F4} {r.PlaneAltitude:F1}ft {r.PlaneHeadingDegreesTrue:F1}deg {r.AirspeedTrueInMeterPerSecond:F0}m/s {r.AirspeedTrueInKnot:F0}kt");
            }
        }
    }
}
```

## Managers

### Aircraft Manager

The aircraft manager is a simple addon to the FsConnect that provides a common way to query Flight Simulator for details about the user's aircraft.

The manager can either poll as often as needed, or set up to continously get updates, typically every second, from Fligth Simulator.

The definition for the data to be requested needs to be done from FsConnect using _RegisterDataDefinition_ and the type then provided to the aircraft manager. See the example for how to register the PlaneInfoResponse definition.

```csharp

AircraftManager aircraftManager =
                new AircraftManager<PlaneInfoResponse>(fsConnect, Definitions.PlaneInfo, Requests.AircraftManager);

aircraftManager.Updated += (sender, args) => Console.WriteLine(args.AircraftInfo.ToString());

// Set request method to continuously to start automatic updates using the Updated event.
aircraftManager.RequestMethod = RequestMethod.Continuously;

// Set request method to poll to manually poll Flight Simulator.
aircraftManager.RequestMethod = RequestMethod.Poll;
var aircraftInfo = aircraftManager.Get();

```

Future updates will provide more functionality such as setting key variables.

The test console has an example for how to use the Aircraft Manager, see the AircraftMenu class.

### Sim Object Manager     

The Sim Object Manager is a addon to the FsConnect to avoid making the base library handle every case imaginable. The manager can request information about Sim Objects. As with the Aircraft Manager, the definiton of what to returned is done by using FsConnect.

See the example for how to register the PlaneInfoResponse definition.

```csharp

SimObjectManager simObjectManager = new SimObjectManager<PlaneInfoResponse>(_fsConnect, Definitions.PlaneInfo, Requests.SimObjects);

// Set the geographical radius, in meters, that sim objects will be returned from.
simObjectManager.Radius = 100 * 1000;

// Specify the type of sim objects to fetch
simObjectManager.SimObjectType = FsConnectSimobjectType.Aircraft;

// Gets and returns in one operation
var simObjects = _simObjectManager.GetWithRequest();

// Another way is to asynchronously execute a request, and get the returned Sim Objects later.
simObjectManager.Request();

// Wait for request to complete and get cached sim objects
List<PlaneInfoResponse> simObjects = _simObjectManager.GetList();

```

Future updates will provide more functionality such as updating sim objects.

The test console has an example for how to use the Sim Object Manager, see the SimObjectMenu class.

### World Manager

The world manager currently supports updating the time in flight simulator.

```csharp

WorldManager worldManager = new WorldManager(fsConnect);
worldManager.SetTime(new DateTime(year, month, day, hour, minute, 0));

```

## Community

* Have you find a bug? Do you have an idea for a new feature? ... [open an issue on GitHub](https://github.com/c-true/FsConnect/issues)
* Do you want to contribute piece of code? ... [submit a pull-request](https://github.com/c-true/FsConnect/pulls)
    * `master` branch contains the code being worked on
    * Or from your own fork

## Change log

## 1.3.1

* [Breaking] SimProperty renamed to SimVar, minor other renames.
* Added support for reflection of SimVars, see the SimVar attribute.
* Added enum, FsEventNameId, for configuring client events using an enum.

## 1.3.0

* Aspect based data definition, using SimVar attribute to define fields.
* Simple support for registering client events.
* Support for setting time in flight simulator, through the WorldManager.

## 1.2.0

* Opened up access to more of SimConnect's API.
* Added support for some key simulator events, such as Pause.
* Added support for requesting data on Sim Objects.
* Added managers as example on how to wrap FsConnect for common operations, such as requesting aircraft or sim object data.
* Documentation and refactorings.