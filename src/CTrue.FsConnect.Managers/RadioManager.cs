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
        private int _groupId;
        private int _com1StbyRadioSetEventId;
        private int _com2StbyRadioSetEventId;

        public RadioManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _groupId = _fsConnect.GetNextId();

            _com1StbyRadioSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com1StbyRadioSetEventId, FsEventNameId.ComStbyRadioSet);

            _com2StbyRadioSetEventId = _fsConnect.GetNextId();
            _fsConnect.MapClientEventToSimEvent(_groupId, _com2StbyRadioSetEventId, FsEventNameId.Com2StbyRadioSet);
            
            _fsConnect.SetNotificationGroupPriority(_groupId);
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
    }
}