using System;
using System.Collections.Generic;
using System.Linq;

namespace CTrue.FsConnect.TestConsole
{
    public abstract class Menu
    {
        protected readonly IFsConnect _fsConnect;
        protected Dictionary<ConsoleKey, MenuItem> _menuItems = new Dictionary<ConsoleKey, MenuItem>();

        protected Menu(IFsConnect fsConnect)
        {
            _fsConnect = fsConnect;
        }

        protected virtual void SetUpMenu()
        {
            _menuItems.Clear();

            Add(new MenuItem()
            {
                Key = ConsoleKey.Escape,
                Description = "ESC - To parent menu",
                Handler = NavigateToParentMenu
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.H,
                Description = "H - Display help",
                Handler = ShowHelp
            });

            Add(new MenuItem()
            {
                Key = ConsoleKey.P,
                Description = "P - Pause",
                Handler = Pause
            });
        }

        protected void Add(MenuItem menuItem)
        {
            _menuItems.Add(menuItem.Key, menuItem);
        }

        protected virtual void TearDownMenu()
        {
        }

        public void ShowMenu()
        {
            Console.WriteLine($"-- {GetType().Name} --");
            _menuItems.Values.ToList().ForEach(m => Console.WriteLine(m.Description));
        }

        public void Run()
        {
            SetUpMenu();
            ShowMenu();

            bool navigateToParentMenu;

            do
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                navigateToParentMenu = HandleKey(cki);

                if (navigateToParentMenu)
                    TearDownMenu();
            } 
            while (!navigateToParentMenu);
        }

        public bool HandleKey(ConsoleKeyInfo cki)
        {
            if (!_menuItems.ContainsKey(cki.Key)) return false;

            return _menuItems[cki.Key].Handler.Invoke();
        }

        protected virtual bool NavigateToParentMenu()
        {
            return true;
        }

        protected bool NavigateToMenu<T>() where T : Menu
        {
            Menu subMenu = Activator.CreateInstance(typeof(T), _fsConnect) as Menu;

            subMenu?.Run();

            ShowMenu();

            return false;
        }

        //
        // Handlers
        //

        protected bool ShowHelp()
        {
            ShowMenu();

            return false;
        }

        protected bool Pause()
        {
            _fsConnect.Pause();

            return false;
        }
    }

    public class MenuItem
    {
        public ConsoleKey Key { get; set; }
        public string Description { get; set; }
        public Func<bool> Handler { get; set; }
    }
}