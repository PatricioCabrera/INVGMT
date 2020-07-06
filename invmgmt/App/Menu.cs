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
            bool stay = true;

            ShowMainMenu();

            opt = Functions.ValidateInteger(0, 5);
            Console.Clear();
            switch (opt)
            {
                case 1:
                    SubMenuViewDevices();
                    break;

                case 2:
                    Engine.ShowLookForDevices();
                    Functions.PressAnyKey();
                    break;

                case 3:
                    Engine.ShowAddDevice();
                    Functions.PressAnyKey();
                    break;

                case 4:
                    Engine.ShowModifyDevice();
                    Functions.PressAnyKey();
                    break;

                case 5:
                    break;

                case 0:
                    Functions.TurnOFF();
                    stay = false;
                    break;
            }

            return stay;
        }

        public static void ShowMainMenu()
        {
            Functions.ShowTitle("Menu Principal");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  1. Mostrar Equipos");
            Console.WriteLine("  2. Buscar Equipos por número de serie");
            Console.WriteLine("  3. Agregar Equipo");
            Console.WriteLine("  4. Modificar Equipo");
            Console.WriteLine("  5. Eliminar Equipo");
            Console.WriteLine("  0. Salir del sistema");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nIngrese una opción: ");
            Console.ResetColor();
        }

        public static void SubMenuViewDevices()
        {
            int opt;
            bool stay = true;

            do
            {
                Console.Clear();
                ShowSubMenuViewDevices();

                opt = Functions.ValidateInteger(0, 5);
                Console.Clear();
                switch (opt)
                {
                    case 1:
                        Engine.ShowDevices();
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 2:
                        Engine.ShowDevices(true, false, false);
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 3:
                        Engine.ShowDevices(false, true, false);
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 4:
                        Engine.ShowDevices(true, true, true);
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 0:
                        stay = Functions.StayIn("Ver dispositivos");
                        break;
                }
            } while (stay);
        }

        private static void ShowSubMenuViewDevices()
        {
            Functions.ShowTitle("Ver dispositivos");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  1. Ver todos");
            Console.WriteLine("  2. Ver Notebooks");
            Console.WriteLine("  3. Ver PC's");
            Console.WriteLine("  4. Ver equipos sin usar");
            Console.WriteLine("  0. Atrás");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nIngrese una opción: ");
            Console.ResetColor();
        }

        public static void SubMenuLookDevices()
        {
            int opt;
            bool stay = true;

            do
            {
                Console.Clear();
                ShowSubMenuViewDevices();

                opt = Functions.ValidateInteger(0, 5);
                Console.Clear();
                switch (opt)
                {
                    case 1:
                        Engine.ShowDevices();
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 2:
                        Engine.ShowDevices(true, false, false);
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 3:
                        Engine.ShowDevices(false, true, false);
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 4:
                        Engine.ShowDevices(true, true, true);
                        stay = Functions.StayIn("Ver dispositivos");
                        break;

                    case 0:
                        stay = Functions.StayIn("Ver dispositivos");
                        break;
                }
            } while (stay);
        }

        private static void ShowSubMenuLookDevices()
        {
            Functions.ShowTitle("Ver dispositivos");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  1. Ver todos");
            Console.WriteLine("  2. Ver Notebooks");
            Console.WriteLine("  3. Ver PC's");
            Console.WriteLine("  4. Ver equipos sin usar");
            Console.WriteLine("  0. Atrás");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nIngrese una opción: ");
            Console.ResetColor();
        }
    }
}
