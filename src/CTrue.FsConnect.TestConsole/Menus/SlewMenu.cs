using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace CTrue.FsConnect.TestConsole
{
    public class SlewMenu : Menu
    {
        private readonly AutoResetEvent _pollPlanePositionResetEvent = new AutoResetEvent(false);


        private PlaneInfoResponse _planeInfoResponse;
        private PlanePosition _planePosition;

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
            base.TearDownMenu();

            _fsConnect.FsDataReceived -= HandleReceivedFsData;
        }

        //
        // Event handlers
        //

        private void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.Data == null || e.Data.Count == 0) throw new Exception("No data returned");

                if (e.RequestId == (uint)Requests.PlaneInfo)
                {
                    _planeInfoResponse = (PlaneInfoResponse)e.Data.FirstOrDefault();
                    
                    Console.WriteLine(_planeInfoResponse.ToString());
                }
                else if (e.RequestId == (uint)Requests.PlanePosition)
                {
                    _planePosition = (PlanePosition)e.Data.FirstOrDefault();

                    _pollPlanePositionResetEvent.Set();
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

        private void PollPlanePosition()
        {
            _fsConnect.RequestData(Requests.PlanePosition, Definitions.PlanePosition);
            _pollPlanePositionResetEvent.WaitOne(1000);
        }

        private bool IncreaseAltitude()
        {
            PollPlanePosition();
            _planePosition.Altitude += _deltaAltitude;
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }

        private bool DecreaseAltitude()
        {
            PollPlanePosition();
            _planePosition.Altitude -= _deltaAltitude;
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }

        private bool RotateRight()
        {
            PollPlanePosition();
            _planePosition.Heading += FsUtils.Deg2Rad(_deltaHeading);
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }

        private bool RotateLeft()
        {
            PollPlanePosition();
            _planePosition.Heading -= FsUtils.Deg2Rad(_deltaHeading);
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }

        private bool MoveRight()
        {
            PollPlanePosition();
            _planePosition.Longitude += _deltaLongitude;
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }

        private bool MoveLeft()
        {
            PollPlanePosition();
            _planePosition.Longitude -= _deltaLongitude;
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);

            return false;
        }

        private bool MoveBackward()
        {
            PollPlanePosition();
            _planePosition.Latitude -= _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }

        private bool MoveForward()
        {
            PollPlanePosition();
            _planePosition.Latitude += _deltaLatitude;
            _fsConnect.UpdateData(Definitions.PlanePosition, _planePosition);
            PollFlightSimulator();

            return false;
        }
    }
}