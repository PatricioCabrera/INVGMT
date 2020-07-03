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
        public static List<IDevices> devicesList = new List<IDevices>();

        public static void InitProgram()
        {
            Functions.TurnON();
            LoadInitialUsers();
            DebugDevices();
            ShowDevices();
            Console.ReadKey();
            Functions.TurnOFF();
            Environment.Exit(0);
        }
        public static void LoadInitialUsers()
        {
            Notebook nb00 = new Notebook() { Brand = NotebookBrands.ASUS, Model = NotebookModels.ZenBook, Serial = "PFG564BHX" };
            Notebook nb01 = new Notebook() { Brand = NotebookBrands.Banghó, Model = NotebookModels.Bes, Serial = "GUI864B4K" };
            Notebook nb02 = new Notebook() { Brand = NotebookBrands.ASUS, Model = NotebookModels.ZenBook, Serial = "HFK542HGB" };

            nb00.User = new User("Pepton", "Peptoso");
            nb01.User = new User("María", "Shakiltrufia");
            nb02.User = new User("Óscar", "Ornamental");

            devicesList.Add(nb00);
            devicesList.Add(nb01);
            devicesList.Add(nb02);
        }

        public static void DebugDevices()
        {
            foreach (Notebook note in devicesList)
            {
                Console.WriteLine(note);
                Console.WriteLine(note.User);
            }
        }

        public static void ShowDevices(bool filterNotebooks = true, bool filterDesktops = true, bool notInUse = false)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("| {0,-10}  | {1, -8}  | {2, -8}  | {3, -20} | {4, -20}  \n", "TIPO", "MARCA", "MODELO", "SERIAL", "USUARIO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            if (filterNotebooks && devicesList.OfType<Notebook>().FirstOrDefault() != null)
            {
                if (!notInUse)
                {
                    foreach (Notebook note in devicesList)
                    {
                        Console.Write("| {0, -10}  ", "Notebook");
                        Console.Write("| {0, -8}  ", note.Brand);
                        Console.Write("| {0, -8}  ", note.Model);
                        Console.Write("| {0, -20} ", note.Serial);
                        Console.Write("| {0, -10}{1, -10} ", note.User.Name, note.User.LastName);
                        Console.WriteLine();
                    }
                }
                else
                {
                    foreach (Notebook note in devicesList)
                    {
                        if (note.User != null)
                        {
                            Console.Write("| {0, -10}  ", "Notebook");
                            Console.Write("| {0, -8}  ", note.Brand);
                            Console.Write("| {0, -8}  ", note.Model);
                            Console.Write("| {0, -20} ", note.Serial);
                            Console.Write("| {0, -10}{1, -10} ", note.User.Name, note.User.LastName);
                            Console.WriteLine();
                        }
                    }
                }
            }
            if (filterDesktops && devicesList.OfType<Desktop>().FirstOrDefault() != null)
            {
                if (!notInUse)
                {
                    foreach (Desktop desk in devicesList)
                    {
                        Console.Write("| {0, -10}  ", "PC");
                        Console.Write("| {0, -8}  ", desk.Brand);
                        Console.Write("| {0, -8}  ", desk.Model);
                        Console.Write("| {0, -20} ", desk.Serial);
                        Console.Write("| {0, -10}{1, -10} ", desk.User.Name, desk.User.LastName);
                        Console.WriteLine();
                    }
                }
                else
                {
                    foreach (Desktop desk in devicesList)
                    {
                        if (desk.User != null)
                        {
                            Console.Write("| {0, -10}  ", "PC");
                            Console.Write("| {0, -8}  ", desk.Brand);
                            Console.Write("| {0, -8}  ", desk.Model);
                            Console.Write("| {0, -20} ", desk.Serial);
                            Console.Write("| {0, -10}{1, -10} ", desk.User.Name, desk.User.LastName);
                            Console.WriteLine();
                        }
                    }
                }
            }

        }
    }

    //public static Devices AddDevice(bool isNotebook)
    //{
    //    if (isNotebook)
    //    {
    //        Notebook notebook = new Notebook() { };
    //        Console.WriteLine("¿Qué modelo de Notebook?");
    //        Console.WriteLine(notebook.Model);
    //        Console.WriteLine("¿Qué marca de Notebook?");
    //        notebook.ReturnAvailableBrands();

    //        return notebook;
    //    }
    //    else
    //    {
    //        Desktops desktop = new Desktops() { };
    //        Console.WriteLine("¿Qué marca de PC?");
    //        Console.WriteLine(desktop.Brand);
    //    }
    //}

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
