using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CTrue.FsConnect.Managers
{
    /// <summary>
    /// The <see cref="IAutoPilotManager"/> controls the autopilot in the current aircraft.
    /// </summary>
    /// <remarks>
    /// Supports:
    /// - Get and set heading bug.
    ///
    /// Usage:
    /// Call <see cref="Update"/> to refresh properties with latest values from MSFS.
    /// </remarks>
    public interface IAutoPilotManager
    {
        /// <summary>
        /// Gets the current heading bug, in degrees.
        /// </summary>
        double HeadingBug { get; }

        /// <summary>
        /// Request new autopilot data from MSFS.
        /// </summary>
        /// <remarks>
        /// The call is blocked until an update is returned.
        /// </remarks>
        void Update();

        /// <summary>
        /// Sets the autopilot heading bug, in degrees.
        /// </summary>
        /// <param name="heading"></param>
        void SetHeadingBug(double heading);
    }

    /// <inheritdoc />
    public class AutopilotManager : IAutoPilotManager
    {
        private readonly IFsConnect _fsConnect;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int _eventGroupId;
        
        private AutopilotSimVars _autopilotSimVars = new AutopilotSimVars();
        private int _autoPilotManagerSimVarsReqId;
        private int _autoPilotManagerSimVarsDefId;

        private int _headingBugSetEventId;

        /// <inheritdoc />
        public double HeadingBug { get; private set; }

        /// <summary>
        /// Creates a new <see cref="AutopilotManager"/> instance.
        /// </summary>
        /// <param name="fsConnect"></param>
        public AutopilotManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            _fsConnect.FsDataReceived += OnFsDataReceived;
            RegisterSimVars();
            RegisterEvents();
        }

        private void RegisterSimVars()
        {
            _autoPilotManagerSimVarsReqId = _fsConnect.GetNextId();
            _autoPilotManagerSimVarsDefId = _fsConnect.RegisterDataDefinition<AutopilotSimVars>();
        }

        private void RegisterEvents()
        {
            _eventGroupId = _fsConnect.GetNextId();
            _headingBugSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_eventGroupId, _headingBugSetEventId, FsEventNameId.HeadingBugSet);

            _fsConnect.SetNotificationGroupPriority(_eventGroupId);
        }

        private void OnFsDataReceived(object sender, FsDataReceivedEventArgs e)
        {
            if (e.Data.Count == 0) return;
            if (!(e.Data[0] is AutopilotSimVars)) return;

            _autopilotSimVars = (AutopilotSimVars)e.Data[0];
            _resetEvent.Set();
        }

        /// <inheritdoc />
        public void Update()
        {
            _fsConnect.RequestData(_autoPilotManagerSimVarsReqId, _autoPilotManagerSimVarsDefId);
            bool resetRes = _resetEvent.WaitOne(10000);

            if (!resetRes)
                throw new TimeoutException("Autopilot Manager data was not returned from MSFS within timeout");

            HeadingBug = _autopilotSimVars.HeadingBug;
        }

        /// <inheritdoc />
        public void SetHeadingBug(double heading)
        {
            _fsConnect.TransmitClientEvent(_headingBugSetEventId, (uint)heading, _eventGroupId);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        internal struct AutopilotSimVars
        {
            [SimVar(NameId = FsSimVar.AutopilotHeadingLockDir, UnitId = FsUnit.Degree)]
            public double HeadingBug;
        }
    }
}