using System;
using System.Collections.Generic;
using CTrue.FsConnect.Managers;
using Microsoft.FlightSimulator.SimConnect;
using Serilog;

namespace CTrue.FsConnect.TestConsole
{
    public class SimObjectsMenu : Menu
    {
        private SimObjectManager<PlaneInfoResponse> _simObjectManager;
        private PlaneInfoResponse _planeInfoResponse;

        public SimObjectsMenu(IFsConnect fsConnect) : base(fsConnect)
        {
        }

        protected override void SetUpMenu()
        {
            base.SetUpMenu();

            Add(new MenuItem()
            {
                Key = ConsoleKey.D1,
                Description = "1 - Request Sim Objects",
                Handler = RequestSimObjects
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D2,
                Description = "2 - List Sim Objects",
                Handler = PollSimObjects
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D3,
                Description = "3 - Clear Sim Objects List",
                Handler = ClearSimObjectsList
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D4,
                Description = "4 - Set Radius",
                Handler = SetRadius
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D5,
                Description = "5 - Toggle Sim Object type",
                Handler = ToggleSimObjectType
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D0,
                Description = "0 - Request Sim Objects (Experimental)",
                Handler = RequestAndReturnSimObjects
            });


            _simObjectManager = new SimObjectManager<PlaneInfoResponse>(_fsConnect, Definitions.PlaneInfo, Requests.SimObjects);
            _simObjectManager.Radius = 100 * 1000;
            _simObjectManager.SimObjectType = SIMCONNECT_SIMOBJECT_TYPE.AIRCRAFT;
        }

        private bool RequestSimObjects()
        {
            try
            {
                Console.WriteLine("Requesting Sim Objects");
                _simObjectManager.Request();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        private bool PollSimObjects()
        {
            try
            {
                List<PlaneInfoResponse> simObjects = _simObjectManager.Get();

                ListSimObjects(simObjects);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        private bool ClearSimObjectsList()
        {
            try
            {
                _simObjectManager.Clear();

                Console.WriteLine("Sim Objects list cleared");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        private bool SetRadius()
        {
            Console.Write($"Enter radius [{_simObjectManager.Radius}m]:");
            string radiusString = Console.ReadLine();
            try
            {
                _simObjectManager.Radius = uint.Parse(radiusString);

                Console.WriteLine($"Radius set to {_simObjectManager.Radius} meters");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not a valid radius.");
            }

            return false;
        }

        private bool ToggleSimObjectType()
        {
            _simObjectManager.SimObjectType = _simObjectManager.SimObjectType.Next();
            Console.WriteLine("Current Sim Object type is " + _simObjectManager.SimObjectType.ToString());

            return false;
        }

        private bool RequestAndReturnSimObjects()
        {
            var simObjects = _simObjectManager.GetWithRequest();

            ListSimObjects(simObjects);

            return false;
        }

        private void ListSimObjects(List<PlaneInfoResponse> simObjects)
        {
            Console.WriteLine($"Sim Objects of type {_simObjectManager.SimObjectType.ToString()} within radius {_simObjectManager.Radius} meters:");
            foreach (var simObject in simObjects)
            {
                Console.WriteLine(simObject.ToString());
            }

            Console.WriteLine(simObjects.Count + " Sim Objects in list");
        }

        protected override void Dispose(bool disposing)
        {
            _simObjectManager.Dispose();
            base.Dispose(disposing);
        }
    }

    public static class Extensions
    {

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}