using System;

namespace CTrue.FsConnect.Managers
{
    public enum WorldManagerId
    {
        SetTime = 100,
        SetZuluYears = 101,
        SetZuluDays = 102,
        SetZuluHours = 103,
        SetZuluMinute = 104,
    };

    public class WorldManager
    {
        private readonly IFsConnect _fsConnect;

        public WorldManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;

            _fsConnect.MapClientEventToSimEvent(WorldManagerId.SetTime, WorldManagerId.SetZuluYears, FsEventNameId.ZuluYearSet);
            _fsConnect.MapClientEventToSimEvent(WorldManagerId.SetTime, WorldManagerId.SetZuluDays, FsEventNameId.ZuluDaySet);
            _fsConnect.MapClientEventToSimEvent(WorldManagerId.SetTime, WorldManagerId.SetZuluHours, FsEventNameId.ZuluHoursSet);
            _fsConnect.MapClientEventToSimEvent(WorldManagerId.SetTime, WorldManagerId.SetZuluMinute, FsEventNameId.ZuluMinutesSet);

            _fsConnect.SetNotificationGroupPriority(WorldManagerId.SetTime);
        }

        public void SetTime(DateTime time)
        {
            _fsConnect.TransmitClientEvent(WorldManagerId.SetZuluYears, (uint)time.Year, WorldManagerId.SetTime);
            _fsConnect.TransmitClientEvent(WorldManagerId.SetZuluDays, (uint)time.DayOfYear, WorldManagerId.SetTime);
            _fsConnect.TransmitClientEvent(WorldManagerId.SetZuluHours, (uint)time.Hour, WorldManagerId.SetTime);
            _fsConnect.TransmitClientEvent(WorldManagerId.SetZuluMinute, (uint)time.Minute, WorldManagerId.SetTime);
        }
    }
}