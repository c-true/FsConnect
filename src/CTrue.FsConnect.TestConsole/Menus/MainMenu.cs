using System;
using CTrue.FsConnect.Managers;

namespace CTrue.FsConnect.TestConsole
{
    public class MainMenu : Menu
    {
        private WorldManager _worldManager;

        public MainMenu(IFsConnect fsConnect) : base(fsConnect)
        {
            _worldManager = new WorldManager(_fsConnect);
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
            DateTime utc = DateTime.UtcNow;

            Console.WriteLine("Year:");
            string input = Console.ReadLine();
            int year = int.Parse(input);

            Console.WriteLine("Month:");
            input = Console.ReadLine();
            int month = int.Parse(input);

            Console.WriteLine("Day:");
            input = Console.ReadLine();
            int day = int.Parse(input);

            Console.WriteLine("Hour:");
            input = Console.ReadLine();
            int hour = int.Parse(input);

            Console.WriteLine("Minutes:");
            input = Console.ReadLine();
            int minute = int.Parse(input);

            _worldManager.SetTime(new DateTime(year, month, day, hour, minute, 0));

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