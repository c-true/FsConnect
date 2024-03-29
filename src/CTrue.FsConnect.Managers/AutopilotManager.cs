﻿using System;
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
    public interface IAutoPilotManager : IFsConnectManager
    {
        /// <summary>
        /// Gets the current heading bug, in degrees.
        /// </summary>
        double HeadingBug { get; }

        /// <summary>
        /// Gets the current autopilot altitude, in feets.
        /// </summary>
        double Altitude { get; }

        double VerticalSpeed { get; }

        /// <summary>
        /// Sets the autopilot heading bug, in degrees.
        /// </summary>
        /// <param name="heading"></param>
        void SetHeadingBug(double heading);

        /// <summary>
        /// Sets the autopilot altitude, in degrees.
        /// </summary>
        /// <param name="altitude"></param>
        void SetAltitude(double altitude);

        /// <summary>
        /// Sets the autopilot vertical speed, in feet per minute
        /// </summary>
        /// <param name="verticalSpeed"></param>
        void SetVerticalSpeed(double verticalSpeed);
    }

    /// <inheritdoc />
    public class AutopilotManager : FsConnectManager, IAutoPilotManager
    {
        private int _eventGroupId;
        
        private AutopilotSimVars _autopilotSimVars = new AutopilotSimVars();
        private int _autoPilotManagerSimVarsReqId;
        private int _autoPilotManagerSimVarsDefId;

        private int _headingBugSetEventId;
        private int _altitudeSetEventId;
        private int _verticalSpeedSetEventId;

        /// <inheritdoc />
        public double HeadingBug { get; private set; }

        /// <inheritdoc />
        public double Altitude { get; private set; }

        public double VerticalSpeed { get; private set; }

        /// <summary>
        /// Creates a new <see cref="AutopilotManager"/> instance.
        /// </summary>
        /// <param name="fsConnect"></param>
        public AutopilotManager(IFsConnect fsConnect)
            : base(fsConnect)
        {
        }

        protected override void RegisterSimVars()
        {
            _autoPilotManagerSimVarsReqId = _fsConnect.GetNextId();
            _autoPilotManagerSimVarsDefId = _fsConnect.RegisterDataDefinition<AutopilotSimVars>();
        }

        protected override void RegisterEvents()
        {
            _eventGroupId = _fsConnect.GetNextId();
            _headingBugSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_eventGroupId, _headingBugSetEventId, FsEventNameId.HeadingBugSet);

            _altitudeSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_eventGroupId, _altitudeSetEventId, FsEventNameId.ApAltVarSetEnglish);

            _verticalSpeedSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_eventGroupId, _verticalSpeedSetEventId, FsEventNameId.ApVsVarSetEnglish);


            _fsConnect.SetNotificationGroupPriority(_eventGroupId);
        }

        protected override void OnFsDataReceived(object sender, FsDataReceivedEventArgs e)
        {
            if (e.Data.Count == 0) return;
            if (!(e.Data[0] is AutopilotSimVars)) return;

            _autopilotSimVars = (AutopilotSimVars)e.Data[0];
            _resetEvent.Set();
        }

        /// <inheritdoc />
        public override void Update()
        {
            _fsConnect.RequestData(_autoPilotManagerSimVarsReqId, _autoPilotManagerSimVarsDefId);
            WaitForUpdate();

            HeadingBug = _autopilotSimVars.HeadingBug;
            Altitude = _autopilotSimVars.Altitude;
            VerticalSpeed = _autopilotSimVars.VerticalSpeed;
        }

        /// <inheritdoc />
        public void SetHeadingBug(double heading)
        {
            _fsConnect.TransmitClientEvent(_headingBugSetEventId, (uint)heading, _eventGroupId);
        }

        /// <inheritdoc />
        public void SetAltitude(double altitude)
        {
            _fsConnect.TransmitClientEvent(_altitudeSetEventId, (uint)altitude, _eventGroupId);
        }

        /// <inheritdoc />
        public void SetVerticalSpeed(double verticalSpeed)
        {
            _fsConnect.TransmitClientEvent(_verticalSpeedSetEventId, (uint)verticalSpeed, _eventGroupId);
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        internal struct AutopilotSimVars
        {
            [SimVar(NameId = FsSimVar.AutopilotHeadingLockDir, UnitId = FsUnit.Degree)]
            public double HeadingBug;

            [SimVar(NameId = FsSimVar.AutopilotAltitudeLockVar, UnitId = FsUnit.Feet)]
            public double Altitude;

            [SimVar(NameId = FsSimVar.AutopilotVerticalHoldVar, UnitId = FsUnit.FeetPerMinute)]
            public double VerticalSpeed;
        }
    }
}