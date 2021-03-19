using System;
using CTrue.FsConnect.Managers;

namespace CTrue.FsConnect.TestConsole
{
    public class MainMenu : Menu
    {
        public MainMenu(IFsConnect fsConnect) : base(fsConnect)
        {
        }

        protected override void SetUpMenu()
        {
            base.SetUpMenu();

            Add(new MenuItem()
            {
                Key = ConsoleKey.D0,
                Description = "0 - Slew",
                Handler = NavigateToMenu<SlewMenu>
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D1,
                Description = "1 - Poll Sim Objects",
                Handler = NavigateToMenu<SimObjectsMenu>
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D2,
                Description = "2 - Aircraft information",
                Handler = NavigateToMenu<AircraftMenu>
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.D3,
                Description = "3 - Set time",
                Handler = SetTime
            });
        }

        private bool SetTime()
        {
            WorldManager worldManager = new WorldManager(_fsConnect);
            DateTime utc = DateTime.UtcNow;
            
            worldManager.SetTime(utc);

            return false;
        }

        protected override bool NavigateToParentMenu()
        {
            _fsConnect.SetText("Test Console disconnecting", 1);
            _fsConnect.Disconnect();

            return true;
        }
    }
}