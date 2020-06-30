using invmgmt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.App
{
    class Menu
    {
        public static bool MainMenu()
        {
            Console.Clear();
            int opt;
            bool awake = true;

            ShowMainMenu();

            opt = Functions.ValidateInteger(0, 5);
            Console.Clear();
            switch (opt)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 0:
                    Functions.TurnOFF();
                    awake = false;
                    break;
            }

            return awake;
        }

        public static void ShowMainMenu()
        {
            Functions.ShowTitle("Menu Principal");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  1. Mostrar Equipos");
            Console.WriteLine("  2. Buscar Equipo");
            Console.WriteLine("  3. Agregar Equipo");
            Console.WriteLine("  4. Modificar Equipo");
            Console.WriteLine("  5. Eliminar Equipo");
            Console.WriteLine("  0. Salir del sistema");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nIngrese una opción: ");
            Console.ResetColor();
        }
    }
}
