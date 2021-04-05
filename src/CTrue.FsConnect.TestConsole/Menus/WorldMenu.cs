using System;
using CTrue.FsConnect.Managers;

namespace CTrue.FsConnect.TestConsole
{
    public class WorldMenu : Menu
    {
        private WorldManager _worldManager;

        public WorldMenu(IFsConnect fsConnect) : base(fsConnect)
        {
            _worldManager = new WorldManager(fsConnect);
        }

        protected override void SetUpMenu()
        {
            base.SetUpMenu();

            Add(new MenuItem()
            {
                Key = ConsoleKey.D1,
                Description = "1 - Set Time",
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}