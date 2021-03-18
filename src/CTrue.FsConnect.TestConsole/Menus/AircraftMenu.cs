using System;
using CTrue.FsConnect.Managers;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect.TestConsole
{
    public class AircraftMenu : Menu
    {
        private PlaneInfoResponse _planeInfo;
        private bool _updatedEnabled;
        private readonly AircraftManager<PlaneInfoResponse> _aircraftManager;

        public AircraftMenu(IFsConnect fsConnect) : base(fsConnect)
        {
            _aircraftManager =
                new AircraftManager<PlaneInfoResponse>(fsConnect, Definitions.PlaneInfo, Requests.AircraftManager);

            _aircraftManager.Updated += (sender, args) => Console.WriteLine(args.AircraftInfo.ToString());
        }

        protected override void SetUpMenu()
        {
            base.SetUpMenu();

            Add(new MenuItem()
            {
                Key = ConsoleKey.D1,
                Description = "1 - Poll Aircraft information",
                Handler = PollAircraftInfoUpdates
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D2,
                Description = "2 - Toggle periodic Aircraft information",
                Handler = TogglePeriodicAircraftInfoUpdates
            });
        }

        private bool PollAircraftInfoUpdates()
        {
            _planeInfo = _aircraftManager.Get();
            // The Update event handlers will do the logging.

            return false;
        }

        private bool TogglePeriodicAircraftInfoUpdates()
        {
            _updatedEnabled = !_updatedEnabled;

            _aircraftManager.RequestMethod = _updatedEnabled ? RequestMethod.Continuously : RequestMethod.Poll;
            
            Console.WriteLine($"Automatic updates: {(_updatedEnabled ? "Enabled" : "Disabled")}");

            return false;
        }

        protected override void Dispose(bool disposing)
        {
            _aircraftManager.Dispose();
            base.Dispose(disposing);
        }
    }
}