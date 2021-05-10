using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace CTrue.FsConnect.Managers
{
    /// <summary>
    /// The <see cref="IRadioManager"/> controls the navigation and communication radios in the current aircraft.
    /// </summary>
    public interface IRadioManager
    {
        /// <summary>
        /// Sets the COM1 frequency using BCD16 value.
        /// </summary>
        /// <param name="frequency">The BCD16 value, omitting the leading 1. E.g. 0x2400 equals 124.00</param>
        /// <remarks>
        /// Currently supports 0.025 MHz increments, so 0x2407 equals 124.075
        /// </remarks>
        void SetCom1StandbyFrequency(uint frequency);

        /// <summary>
        /// Sets the COM2 frequency using BCD16 value.
        /// </summary>
        /// <param name="frequency">The BCD16 value, omitting the leading 1. E.g. 0x2400 equals 124.00</param>
        /// <remarks>
        /// Currently supports 0.025 MHz increments, so 0x2407 equals 124.075
        /// </remarks>
        void SetCom2StandbyFrequency(uint frequency);
    }

    /// <inheritdoc />
    public class RadioManager : IRadioManager
    {
        private readonly IFsConnect _fsConnect;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int _groupId;
        private int _com1StbyRadioSetEventId;
        private int _com2StbyRadioSetEventId;

        private RadioManagerSimVars _radioManagerSimVars = new RadioManagerSimVars();
        private int _radioManagerSimVarsReqId;
        private int _radioManagerSimVarsDefId;
        
        public uint Com1StandbyFrequency
        {
            get => Bcd.Bcd2Dec(_radioManagerSimVars.Com1StandbyFrequency);
            set => SetCom1StandbyFrequency(value);
        }

        public uint Com2StandbyFrequency
        {
            get => Bcd.Bcd2Dec(_radioManagerSimVars.Com2StandbyFrequency);
            set => SetCom2StandbyFrequency(value);
        }

        public RadioManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _fsConnect.FsDataReceived += OnFsDataReceived;
            _groupId = _fsConnect.GetNextId();

            _com1StbyRadioSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1StbyRadioSetEventId, FsEventNameId.ComStbyRadioSet);

            _com2StbyRadioSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2StbyRadioSetEventId, FsEventNameId.Com2StbyRadioSet);
            
            _fsConnect.SetNotificationGroupPriority(_groupId);

            _radioManagerSimVarsReqId = _fsConnect.GetNextId();
            _radioManagerSimVarsDefId = _fsConnect.RegisterDataDefinition<RadioManagerSimVars>();
        }

        private void OnFsDataReceived(object sender, FsDataReceivedEventArgs e)
        {
            if (e.Data.Count == 0) return;
            if (!(e.Data[0] is RadioManagerSimVars)) return;

            _radioManagerSimVars = (RadioManagerSimVars) e.Data[0];
            _resetEvent.Set();
        }

        public void Update()
        {
            _fsConnect.RequestData(_radioManagerSimVarsReqId, _radioManagerSimVarsDefId);
            bool resetRes =_resetEvent.WaitOne(10000);

            if(!resetRes)
                throw new TimeoutException("Radio Manager data was not returned from MSFS within timeout");
        }

        /// <inheritdoc />
        public void SetCom1StandbyFrequency(uint frequency)
        {
            _fsConnect.TransmitClientEvent(_com1StbyRadioSetEventId, frequency, _groupId);
        }

        /// <inheritdoc />
        public void SetCom2StandbyFrequency(uint frequency)
        {
            _fsConnect.TransmitClientEvent(_com2StbyRadioSetEventId, frequency, _groupId);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RadioManagerSimVars
        {
            [SimVar(NameId = FsSimVar.ComStandbyFrequency, UnitId = FsUnit.FrequencyBcd16, Instance = 1)]
            public uint Com1StandbyFrequency;

            [SimVar(NameId = FsSimVar.ComStandbyFrequency, UnitId = FsUnit.FrequencyBcd16, Instance = 2)]
            public uint Com2StandbyFrequency;
        }
    }
}