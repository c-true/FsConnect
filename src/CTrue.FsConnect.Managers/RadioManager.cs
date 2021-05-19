using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.FlightSimulator.SimConnect;

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
        /// <param name="frequency">The frequency, in MHz, e.g. 124.100</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetCom1StandbyFrequency(double frequency);

        /// <summary>
        /// Sets the COM1 active frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.100</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetCom1ActiveFrequency(double frequency);

        /// <summary>
        /// Sets the COM2 standby frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.100</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetCom2StandbyFrequency(double frequency);

        /// <summary>
        /// Sets the COM2 active frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.10</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetCom2ActiveFrequency(double frequency);

        /// <summary>
        /// Swaps COMS1 active and standby frequency.
        /// </summary>
        void Com1Swap();

        /// <summary>
        /// Swaps COMS2 active and standby frequency.
        /// </summary>
        void Com2Swap();

        #region NAV

        /// <summary>
        /// Gets the Nav1 Active frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        /// <remarks>
        /// The active frequency is changed by setting the Nav1 standby frequency and calling <see cref="IRadioManager.Nav1Swap()"/>
        /// </remarks>
        double Nav1ActiveFrequency { get; }

        /// <summary>
        /// Gets the Nav1 Standby frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        double Nav1StandbyFrequency { get; }

        /// <summary>
        /// Gets the Nav2 Active frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        /// <remarks>
        /// The active frequency is changed by setting the Nav2 standby frequency and calling <see cref="IRadioManager.Nav2Swap()"/>
        /// </remarks>
        double Nav2ActiveFrequency { get; }

        /// <summary>
        /// Gets the Nav2 Standby frequency as returned from the last call with <see cref="IRadioManager.Update()"/>.
        /// </summary>
        double Nav2StandbyFrequency { get; }

        /// <summary>
        /// Gets the transponder code.
        /// </summary>
        uint TransponderCode { get; }

        /// <summary>
        /// Sets the Nav1 standby frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.100</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetNav1StandbyFrequency(double frequency);

        /// <summary>
        /// Sets the Nav1 active frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.100</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetNav1ActiveFrequency(double frequency);

        /// <summary>
        /// Sets the Nav2 standby frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.100</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetNav2StandbyFrequency(double frequency);

        /// <summary>
        /// Sets the Nav2 active frequency.
        /// </summary>
        /// <param name="frequency">The frequency, in MHz, e.g. 124.10</param>
        /// <remarks>
        /// Range: 118.000 to 135.975Mhz
        /// </remarks>
        void SetNav2ActiveFrequency(double frequency);

        /// <summary>
        /// Swaps NavS1 active and standby frequency.
        /// </summary>
        void Nav1Swap();

        /// <summary>
        /// Swaps NavS2 active and standby frequency.
        /// </summary>
        void Nav2Swap();

        #endregion

        /// <summary>
        /// Sets the transponder code.
        /// </summary>
        /// <param name="code"></param>
        void SetTransponderCode(uint code);

        /// <summary>
        /// Request new radio data from MSFS.
        /// </summary>
        /// <remarks>
        /// The call is blocked until an update is returned.
        /// </remarks>
        void Update();
    }

    /// <inheritdoc />
    public class RadioManager : IRadioManager
    {
        private readonly IFsConnect _fsConnect;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private int _groupId;

        private int _com1StbyRadioSetHzEventId;
        private int _com1ActiveRadioSetHzEventId;
        private int _com1StbySwapEventId;

        private int _com2StbyRadioSetHzEventId;
        private int _com2ActiveRadioSetHzEventId;
        private int _com2StbySwapEventId;

        private int _nav1StbyRadioSetHzEventId;
        private int _nav1ActiveRadioSetHzEventId;
        private int _nav1StbySwapEventId;

        private int _nav2StbyRadioSetHzEventId;
        private int _nav2ActiveRadioSetHzEventId;
        private int _nav2StbySwapEventId;

        private int _setTransponderCodeEventId;

        private RadioManagerSimVars _radioManagerSimVars = new RadioManagerSimVars();
        private int _radioManagerSimVarsReqId;
        private int _radioManagerSimVarsDefId;

        #region COM

        /// <inheritdoc />
        public double Com1StandbyFrequency { get; private set; }

        /// <inheritdoc />
        public double Com1ActiveFrequency {  get; private set; }

        /// <inheritdoc />
        public double Com2StandbyFrequency { get; private set; }

        /// <inheritdoc />
        public double Com2ActiveFrequency { get; private set; }

        #endregion

        #region NAV

        /// <inheritdoc />
        public double Nav1StandbyFrequency { get; private set; }

        /// <inheritdoc />
        public double Nav1ActiveFrequency { get; private set; }

        /// <inheritdoc />
        public double Nav2StandbyFrequency { get; private set; }

        /// <inheritdoc />
        public double Nav2ActiveFrequency { get; private set; }

        #endregion

        public uint TransponderCode { get; private set; }

        /// <summary>
        /// Creates a new <see cref="RadioManager"/> instance.
        /// </summary>
        /// <param name="fsConnect"></param>
        public RadioManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _fsConnect.FsDataReceived += OnFsDataReceived;
            _groupId = _fsConnect.GetNextId();

            #region COM

            _com1StbyRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1StbyRadioSetHzEventId, FsEventNameId.ComStbyRadioSetHz);

            _com1ActiveRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1ActiveRadioSetHzEventId, FsEventNameId.ComRadioSetHz);

            _com1StbySwapEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1StbySwapEventId, FsEventNameId.ComStbyRadioSwitchTo);

            _com2StbyRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2StbyRadioSetHzEventId, FsEventNameId.Com2StbyRadioSetHz);

            _com2ActiveRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2ActiveRadioSetHzEventId, FsEventNameId.Com2RadioSetHz);

            _com2StbySwapEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2StbySwapEventId, FsEventNameId.Com2RadioSwap);

            #endregion

            #region NAV

            _nav1StbyRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _nav1StbyRadioSetHzEventId, FsEventNameId.Nav1StbyRadioSetHz);

            _nav1ActiveRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _nav1ActiveRadioSetHzEventId, FsEventNameId.Nav1RadioSetHz);

            _nav1StbySwapEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _nav1StbySwapEventId, FsEventNameId.Nav1RadioSwap);

            _nav2StbyRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _nav2StbyRadioSetHzEventId, FsEventNameId.Nav2StbyRadioSetHz);

            _nav2ActiveRadioSetHzEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _nav2ActiveRadioSetHzEventId, FsEventNameId.Nav2RadioSetHz);

            _nav2StbySwapEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _nav2StbySwapEventId, FsEventNameId.Nav2RadioSwap);

            #endregion

            _setTransponderCodeEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _setTransponderCodeEventId, FsEventNameId.XpndrSet);

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

        /// <inheritdoc />
        public void Update()
        {
            _fsConnect.RequestData(_radioManagerSimVarsReqId, _radioManagerSimVarsDefId);
            bool resetRes =_resetEvent.WaitOne(10000);

            if(!resetRes)
                throw new TimeoutException("Radio Manager data was not returned from MSFS within timeout");

            Com1StandbyFrequency = new FrequencyBcd(_radioManagerSimVars.Com1StandbyFrequency).Value;
            Com1ActiveFrequency = new FrequencyBcd(_radioManagerSimVars.Com1ActiveFrequency).Value;
            Com2ActiveFrequency = new FrequencyBcd(_radioManagerSimVars.Com2ActiveFrequency).Value;
            Com2StandbyFrequency = new FrequencyBcd(_radioManagerSimVars.Com2StandbyFrequency).Value;

            Nav1StandbyFrequency = new FrequencyBcd(_radioManagerSimVars.Nav1StandbyFrequency).Value;
            Nav1ActiveFrequency = new FrequencyBcd(_radioManagerSimVars.Nav1ActiveFrequency).Value;
            Nav2ActiveFrequency = new FrequencyBcd(_radioManagerSimVars.Nav2ActiveFrequency).Value;
            Nav2StandbyFrequency = new FrequencyBcd(_radioManagerSimVars.Nav2StandbyFrequency).Value;

            TransponderCode = _radioManagerSimVars.TransponderCode;
        }

        /// <inheritdoc />
        public void SetCom1StandbyFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_com1StbyRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void SetCom1ActiveFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_com1ActiveRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void SetCom2StandbyFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_com2StbyRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void SetCom2ActiveFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_com2ActiveRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void Com1Swap()
        {
            _fsConnect.TransmitClientEvent(_com1StbySwapEventId, 0, _groupId);
        }

        /// <inheritdoc />
        public void Com2Swap()
        {
            _fsConnect.TransmitClientEvent(_com2StbySwapEventId, 0, _groupId);
        }

        /// <inheritdoc />
        public void SetNav1StandbyFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_nav1StbyRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void SetNav1ActiveFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_nav1ActiveRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void SetNav2StandbyFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_nav2StbyRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void SetNav2ActiveFrequency(double frequency)
        {
            FrequencyBcd freqBcd = new FrequencyBcd(frequency);
            _fsConnect.TransmitClientEvent(_nav2ActiveRadioSetHzEventId, freqBcd.Bcd32Value, _groupId);
        }

        /// <inheritdoc />
        public void Nav1Swap()
        {
            _fsConnect.TransmitClientEvent(_nav1StbySwapEventId, 0, _groupId);
        }

        /// <inheritdoc />
        public void Nav2Swap()
        {
            _fsConnect.TransmitClientEvent(_nav2StbySwapEventId, 0, _groupId);
        }

        /// <inheritdoc />
        public void SetTransponderCode(uint code)
        {
            uint bcdCode = Bcd.Dec2Bcd(code);
            _fsConnect.TransmitClientEvent(_setTransponderCodeEventId, bcdCode, _groupId);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        internal struct RadioManagerSimVars
        {
            [SimVar(NameId = FsSimVar.ComActiveFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 1)]
            public uint Com1ActiveFrequency;

            [SimVar(NameId = FsSimVar.ComStandbyFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 1)]
            public uint Com1StandbyFrequency;
            
            [SimVar(NameId = FsSimVar.ComActiveFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 2)]
            public uint Com2ActiveFrequency;

            [SimVar(NameId = FsSimVar.ComStandbyFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 2)]
            public uint Com2StandbyFrequency;


            [SimVar(NameId = FsSimVar.NavActiveFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 1)]
            public uint Nav1ActiveFrequency;

            [SimVar(NameId = FsSimVar.NavStandbyFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 1)]
            public uint Nav1StandbyFrequency;

            [SimVar(NameId = FsSimVar.NavActiveFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 2)]
            public uint Nav2ActiveFrequency;

            [SimVar(NameId = FsSimVar.NavStandbyFrequency, UnitId = FsUnit.FrequencyBcd32, Instance = 2)]
            public uint Nav2StandbyFrequency;

            [SimVar(NameId = FsSimVar.TransponderCode, UnitId = FsUnit.Enum, Instance = 1, DataType = SIMCONNECT_DATATYPE.INT64)]
            public uint TransponderCode;
        }
    }
}