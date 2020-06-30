using invmgmt.Entity;
using invmgmt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.App
{
    public static class Engine
    {
        public static List<Users> listaUsuarios = new List<Users>();

        public static void InitProgram()
        {
            Functions.TurnON();
            LoadInitialUsers();
            DebugDevices();
            Functions.TurnOFF();
            Environment.Exit(0);
        }
        public static void LoadInitialUsers()
        {
            Users usuario1 = new Users("Pepton", "Peptoso");
            Users usuario2 = new Users("María", "Shakiltrufia");
            Users usuario3 = new Users("Óscar", "Ornamental");
            Users usuario4 = new Users("Pedro", "Edro");

            usuario1.Notebook = new Notebooks( NotebookModels.ThinkPad, NotebookBrands.Lenovo, "FGH765YP");
            usuario2.Notebook = new Notebooks( NotebookModels.Bes, NotebookBrands.Banghó, "ETU478KN");

            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
        }

        public static void DebugDevices()
        {
            foreach (var user in listaUsuarios)
            {
                Console.WriteLine(user);

                if (user.Notebook != null)
                {
                    user.ShowNotebook();
                }
                if (user.Desktop != null)
                {
                    user.ShowDesktop();
                }
            }
        }

        public static void ShowAllDevices()
        {

        }

        public static void ShowMatrix(string[,] product, int[,] inventory, int[,] billing)
        {
            int rows = product.GetLength(0);
            int columns = product.GetLength(1);
            int columnsBilling = billing.GetLength(1);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("| {0,-2}  | {1, -20}  | {2, -20}  | {3} | {4, -5}  | {5} | {6}  \n", "ID", "NOMBRE", "CATEGORÍA", "PRECIO", "STOCK", "VENTAS", "FACTURADO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < rows; i++)
            {
                if (product[i, 0] != "-1" && product[i, 0] != null && product[i, 1] != "EspacioDisponible")
                {
                    Console.Write("| ");

                    for (int j = 0; j < columns; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                Console.Write("{0,-2}  | ", product[i, j]);
                                break;
                            case 1:
                                Console.Write("{0,-20}  | ", product[i, j]);
                                break;
                            case 2:
                                Console.Write("{0,-20}  | ", product[i, j]);
                                break;
                            default:
                                break;
                        }
                    }

                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write("{0,-5}  | ", inventory[i, j]);
                    }

                    for (int j = 0; j < columnsBilling; j++)
                    {
                        if (j == 1)
                        {
                            Console.Write("{0,-8}  | ", billing[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
            }

            Functions.PressAnyKey();
        }
    }
}
