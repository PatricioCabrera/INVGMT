using invmgmt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.App
{
    public static class Init
    {
        public static void InitProgram()
        {
            bool awake;
            Functions.TurnON();
            Engine.LoadInitialUsers();
            do
            {
                awake = Menu.MainMenu();
            } while (awake);
            Functions.TurnOFF();
            Environment.Exit(0);
        }
    }
}
