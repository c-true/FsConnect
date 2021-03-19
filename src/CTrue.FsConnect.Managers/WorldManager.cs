using System;

namespace CTrue.FsConnect.Managers
{
    public class WorldManager
    {
        private readonly IFsConnect _fsConnect;

        public WorldManager(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;
        }

        public void SetTime(DateTime dateTime)
        {
            _fsConnect.MapClientEvent(04);
        }

        /*
         KEY_ZULU_HOURS_SET	ZULU_HOURS_SET	Sets hours, zulu time	Shared Cockpit
KEY_ZULU_MINUTES_SET	ZULU_MINUTES_SET	Sets minutes, in zulu time	Shared Cockpit
KEY_ZULU_DAY_SET	ZULU_DAY_SET	Sets day, in zulu time	Shared Cockpit
KEY_ZULU_YEAR_SET	ZULU_YEAR_SET
         */
    }
}