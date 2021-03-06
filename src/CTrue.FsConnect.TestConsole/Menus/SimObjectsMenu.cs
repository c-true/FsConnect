using System;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect.TestConsole
{
    public class SimObjectsMenu : Menu
    {
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
                Description = "1 - Poll Sim Objects",
                Handler = PollSimObjects
            });

            _fsConnect.FsDataReceived += HandleReceivedFsData;
        }

        protected override void TearDownMenu()
        {
            base.TearDownMenu();

            _fsConnect.FsDataReceived -= HandleReceivedFsData;
        }

        private void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.RequestId == (uint)Requests.SimObjects)
                {
                    _planeInfoResponse = (PlaneInfoResponse)e.Data;

                    Console.WriteLine(_planeInfoResponse.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not handle received FS data: " + ex);
            }
        }

        private bool PollSimObjects()
        {
            uint radius = 999 * 1000;
            _fsConnect.RequestData(Requests.SimObjects, Definitions.PlaneInfo, radius, SIMCONNECT_SIMOBJECT_TYPE.AIRCRAFT);

            return false;
        }
    }
}