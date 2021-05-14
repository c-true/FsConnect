using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace CTrue.FsConnect.Managers
{
    /// <summary>
    /// The <see cref="IRadioManager"/> controls the navigation and communication radios in the current aircraft.
    /// </summary>
    /// <remarks>
    /// Note: Currently only 2 decimal frequencies, e.g. 120.25 are supported, not 3 decimal frequencies such as 128.725
    /// </remarks>
    public interface IRadioManager
    {
        /// <summary>
        /// Gets the COM1 Active frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        /// <remarks>
        /// The active frequency is changed by setting the COM1 standby frequency and calling <see cref="IRadioManager.COM1Swap()"/>
        /// </remarks>
        double Com1ActiveFrequency { get; }

        /// <summary>
        /// Gets the COM1 Standby frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        double Com1StandbyFrequency { get; }

        /// <summary>
        /// Gets the COM2 Active frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        /// <remarks>
        /// The active frequency is changed by setting the COM2 standby frequency and calling <see cref="IRadioManager.COM2Swap()"/>
        /// </remarks>
        double Com2ActiveFrequency { get; }

        /// <summary>
        /// Gets the COM2 Standby frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        double Com2StandbyFrequency { get; }

        /// <summary>
        /// Sets the COM1 standby frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.10</param>
        /// <remarks>
        /// Currently supports 0.25 MHz increments.
        /// </remarks>
        void SetCom1StandbyFrequency(double frequency);

        /// <summary>
        /// Sets the COM2 standby frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.10</param>
        /// <remarks>
        /// Currently supports 0.25 MHz increments.
        /// </remarks>
        void SetCom2StandbyFrequency(double frequency);

        /// <summary>
        /// Swaps COMS1 active and standby frequency.
        /// </summary>
        void Com1Swap();

        /// <summary>
        /// Swaps COMS2 active and standby frequency.
        /// </summary>
        void Com2Swap();
    }

    /// <inheritdoc />
    public class RadioManager : IRadioManager
    {
        private readonly IFsConnect _fsConnect;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int _groupId;
        private int _com1StbyRadioSetEventId;
        private int _com1StbySwapEventId;

        private int _com2StbyRadioSetEventId;
        private int _com2StbySwapEventId;

        private RadioManagerSimVars _radioManagerSimVars = new RadioManagerSimVars();
        private int _radioManagerSimVarsReqId;
        private int _radioManagerSimVarsDefId;

        public double Com1ActiveFrequency {  get; private set; }

        public double Com1StandbyFrequency { get; private set; }

        public double Com2ActiveFrequency { get; private set; }

        public double Com2StandbyFrequency { get; private set; }

        public RadioManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            RegisterEvents();
        }

        public void Com1Swap()
        {
            _fsConnect.TransmitClientEvent(_com1StbySwapEventId, 0, _groupId);
        }

        public void Com2Swap()
        {
            _fsConnect.TransmitClientEvent(_com2StbySwapEventId, 0, _groupId);
        }

        private void RegisterEvents()
        {
            _fsConnect.FsDataReceived += OnFsDataReceived;
            _groupId = _fsConnect.GetNextId();

            _com1StbyRadioSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1StbyRadioSetEventId, FsEventNameId.ComStbyRadioSet);

            _com1StbySwapEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1StbySwapEventId, FsEventNameId.ComStbyRadioSwitchTo);

            _com2StbyRadioSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2StbyRadioSetEventId, FsEventNameId.Com2StbyRadioSet);

            _com2StbySwapEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2StbySwapEventId, FsEventNameId.Com2RadioSwap);

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

            Com1ActiveFrequency = new FrequencyBcd(_radioManagerSimVars.Com1ActiveFrequency).Value;
            Com1StandbyFrequency = new FrequencyBcd(_radioManagerSimVars.Com1StandbyFrequency).Value;
            Com2ActiveFrequency = new FrequencyBcd(_radioManagerSimVars.Com2ActiveFrequency).Value;
            Com2StandbyFrequency = new FrequencyBcd(_radioManagerSimVars.Com2StandbyFrequency).Value;
        }

        /// <inheritdoc />
        public void SetCom1StandbyFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_com1StbyRadioSetEventId, freqBcd.BcdValue, _groupId);
        }

        /// <inheritdoc />
        public void SetCom2StandbyFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_com2StbyRadioSetEventId, freqBcd.BcdValue, _groupId);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct RadioManagerSimVars
        {
            [SimVar(NameId = FsSimVar.ComActiveFrequency, UnitId = FsUnit.FrequencyBcd16, Instance = 1)]
            public uint Com1ActiveFrequency;

            [SimVar(NameId = FsSimVar.ComStandbyFrequency, UnitId = FsUnit.FrequencyBcd16, Instance = 1)]
            public uint Com1StandbyFrequency;
            
            [SimVar(NameId = FsSimVar.ComActiveFrequency, UnitId = FsUnit.FrequencyBcd16, Instance = 2)]
            public uint Com2ActiveFrequency;

            [SimVar(NameId = FsSimVar.ComStandbyFrequency, UnitId = FsUnit.FrequencyBcd16, Instance = 2)]
            public uint Com2StandbyFrequency;

        }
    }
}