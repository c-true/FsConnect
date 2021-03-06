using System;

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
        }

        protected override bool NavigateToParentMenu()
        {
            _fsConnect.SetText("Test Console disconnecting", 1);
            _fsConnect.Disconnect();

            return true;
        }
    }
}