using System;
using CTrue.FsConnect.Managers;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect.TestConsole
{
    public class AircraftMenu : Menu
    {
        private PlaneInfoResponse _planeInfo;
        private bool _updatedEnabled;
        private AircraftManager<PlaneInfoResponse> _aircraftManager;

        public AircraftMenu(IFsConnect fsConnect) : base(fsConnect)
        {
            _aircraftManager =
                new AircraftManager<PlaneInfoResponse>(fsConnect, Definitions.PlaneInfo, Requests.AircraftManager);
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
            Console.WriteLine(_planeInfo.ToString());

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