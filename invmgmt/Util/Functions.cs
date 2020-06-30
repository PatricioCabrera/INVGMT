using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.Util
{
    class Functions
    {
        public static void ShowTitle(string text)
        {
            string titulo = "========== " + text.Trim() + " ==========";
            string asterisquines = string.Empty;

            for (int i = 0; i < titulo.Length; i++)
            {
                asterisquines += "*";
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(asterisquines);
            Console.WriteLine(titulo);
            Console.WriteLine(asterisquines);
            Console.WriteLine();
        }

        public static int ValidateInteger(int opcionMin, int opcionMax)
        {
            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < opcionMin || opcion > opcionMax)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error,reingrese opcion valida.\nIngrese una opcion entre {0} y {1}", opcionMin, opcionMax);
            }
            Console.ResetColor();

            return opcion;

        }
        public static bool ValidateConfirmation(string aux)
        {
            while (string.IsNullOrEmpty(aux) || (aux.ToLower().Trim() != "y" && aux.ToLower().Trim() != "n"))
            {
                Error("Error,reingrese opcion valida.\nIngrese N o Y");
                aux = Console.ReadLine();
            }
            Console.ResetColor();

            if (aux == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ValidateYoN(string aux)
        {
            while (string.IsNullOrEmpty(aux) || (aux.ToLower().Trim() != "a" && aux.ToLower().Trim() != "b"))
            {
                Error("Error, ingrese opcion valida.\nIngrese A o B");
                aux = Console.ReadLine();
            }
            Console.ResetColor();

            return aux;

        }

        public static void PressAKey(string tecla, string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPresione ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(" " + tecla + " ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(mensaje);
            Console.WriteLine();
        }

        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("\nPresiona cualquier tecla para continuar");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();

        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.Beep(600, 500);
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.Beep(300, 500);
            Console.ResetColor();
        }

        public static void TurnON()
        {
            Console.Beep(200, 150);
            Console.Beep(400, 150);
            Console.Beep(600, 150);
        }

        public static void TurnOFF()
        {
            Console.Beep(600, 150);
            Console.Beep(400, 150);
            Console.Beep(200, 150);
        }
    }
}
