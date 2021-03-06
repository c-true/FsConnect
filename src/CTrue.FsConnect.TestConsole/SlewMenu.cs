using System;

namespace CTrue.FsConnect.TestConsole
{
    public class SlewMenu : Menu
    {
        private PlaneInfoResponse _planeInfoResponse;

        private static double _deltaLatitude = 0.001;
        private static double _deltaLongitude = 0.001;
        private static double _deltaAltitude = 1000;
        private static double _deltaHeading = 10;
    

        public SlewMenu(IFsConnect fsConnect) : base(fsConnect)
        {
        }
        
        protected override void SetUpMenu()
        {
            base.SetUpMenu();
            
            Add(new MenuItem()
            {
                Key = ConsoleKey.L,
                Description = "L - Poll FS for new data",
                Handler = PollFlightSimulator
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.W,
                Description = "W - Forward",
                Handler = MoveForward
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.S,
                Description = "S - Backwards",
                Handler = MoveBackward
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.A,
                Description = "A - Move Left",
                Handler = MoveLeft
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D,
                Description = "D - Move Right",
                Handler = MoveRight
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.Q,
                Description = "Q - Rotate Left",
                Handler = RotateLeft
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.E,
                Description = "E - Rotate Right",
                Handler = RotateRight
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.R, 
                Description = "R - Increase Altitude",
                Handler = IncreaseAltitude
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.F,
                Description = "F - Decrease Altitude",
                Handler = DecreaseAltitude
            });

            _fsConnect.FsDataReceived += HandleReceivedFsData;
        }

        protected override void TearDownMenu()
        {
            _fsConnect.FsDataReceived -= HandleReceivedFsData;
        }

        //
        // Event handlers
        //

        private void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.RequestId == (uint)Requests.PlaneInfo)
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

        //
        // Handlers
        //

        private bool PollFlightSimulator()
        {
            _fsConnect.RequestData(Requests.PlaneInfo, Definitions.PlaneInfo);

            return false;
        }

        private bool IncreaseAltitude()
        {
            _planeInfoResponse.Altitude += _deltaAltitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool DecreaseAltitude()
        {
            _planeInfoResponse.Altitude -= _deltaAltitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool RotateRight()
        {
            _planeInfoResponse.Heading += FsUtils.Deg2Rad(_deltaHeading);
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool RotateLeft()
        {
            _planeInfoResponse.Heading -= FsUtils.Deg2Rad(_deltaHeading);
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool MoveRight()
        {
            _planeInfoResponse.Longitude += _deltaLongitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool MoveLeft()
        {
            _planeInfoResponse.Longitude -= _deltaLongitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool MoveBackward()
        {
            _planeInfoResponse.Latitude -= _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }

        private bool MoveForward()
        {
            _planeInfoResponse.Latitude += _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlaneInfo, _planeInfoResponse);
            PollFlightSimulator();

            return false;
        }
    }
}