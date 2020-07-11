using invmgmt.Entity;
using invmgmt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace invmgmt.App
{
    public static class Engine
    {
        public static List<IDevices> devicesList = new List<IDevices>();

        /// <summary>
        /// Se añaden Notebooks y Desktops en un Array de tipo Idevices, para añadir todos a la Lista devicesList
        /// </summary>
        public static void LoadInitialUsers()
        {
            IDevices[] arrayDevices = new IDevices[7];

            #region
            arrayDevices[0] = new Notebook()
            {
                Brand = NotebookBrands.ASUS,
                Model = NotebookModels.ZenBook,
                Serial = "PFG564BHX",
                User = new User("Pepton", "Peptoso")
            };
            arrayDevices[1] = new Notebook()
            {
                Brand = NotebookBrands.Banghó,
                Model = NotebookModels.Bes,
                Serial = "GUI864B4K",
                User = new User("María", "Mariltrufia")
            };
            arrayDevices[2] = new Notebook()
            {
                Brand = NotebookBrands.ASUS,
                Model = NotebookModels.ZenBook,
                Serial = "HFK542HGB",
                User = new User("Oscar", "Malavibra")
            };
            arrayDevices[3] = new Notebook()
            {
                Brand = NotebookBrands.Lenovo,
                Model = NotebookModels.ThinkPad,
                Serial = "LKI8G4UY"
            };
            arrayDevices[4] = new Desktop()
            {
                Brand = DesktopBrands.Acer,
                Model = DesktopModels.Compacta,
                Serial = "ZHL83E6O",
                User = new User("Carlos", "Cardos")
            };
            arrayDevices[5] = new Desktop()
            {
                Brand = DesktopBrands.ASUS,
                Model = DesktopModels.WorkStation,
                Serial = "LKPR78U6"
            };
            arrayDevices[6] = new Desktop()
            {
                Brand = DesktopBrands.Lenovo,
                Model = DesktopModels.Micro,
                Serial = "OUIK45TH"
            };
            #endregion carga de datos en array
            devicesList.AddRange(arrayDevices);
        }
        public static void ShowDevices(bool filterNotebooks = true, bool filterDesktops = true, bool notInUse = false)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("| {0,-10}  | {1, -8}  | {2, -11}  | {3, -20} | {4, -20}  \n", "TIPO", "MARCA", "MODELO", "SERIAL", "USUARIO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            if (filterNotebooks && devicesList.OfType<Notebook>().FirstOrDefault() != null)
            {
                if (!notInUse)
                {
                    foreach (Notebook note in devicesList.OfType<Notebook>())
                    {
                        Console.Write("| {0, -10}  ", "Notebook");
                        Console.Write("| {0, -8}  ", note.Brand);
                        Console.Write("| {0, -11}  ", note.Model);
                        Console.Write("| {0, -20} ", note.Serial);
                        if (note.User != null)
                        {
                            Console.Write("| {0, -10}{1, -10} ", note.User.Name, note.User.LastName);
                        }
                        else
                        {
                            Console.Write("| {0, -10}{1, -10}", "", "");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    foreach (Notebook note in devicesList.OfType<Notebook>())
                    {
                        if (note.User == null)
                        {
                            Console.Write("| {0, -10}  ", "Notebook");
                            Console.Write("| {0, -8}  ", note.Brand);
                            Console.Write("| {0, -11}  ", note.Model);
                            Console.Write("| {0, -20} ", note.Serial);
                            Console.Write("| {0, -10}{1, -10} ", "", "");
                            Console.WriteLine();
                        }
                    }
                }
            }
            if (filterDesktops && devicesList.OfType<Desktop>().FirstOrDefault() != null)
            {
                if (!notInUse)
                {
                    foreach (Desktop desk in devicesList.OfType<Desktop>())
                    {
                        Console.Write("| {0, -10}  ", "PC");
                        Console.Write("| {0, -8}  ", desk.Brand);
                        Console.Write("| {0, -11}  ", desk.Model);
                        Console.Write("| {0, -20} ", desk.Serial);
                        if (desk.User != null)
                        {
                            Console.Write("| {0, -10}{1, -10} ", desk.User.Name, desk.User.LastName);
                        }
                        else
                        {
                            Console.Write("| {0, -10}{1, -10} ", "", "");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    foreach (Desktop desk in devicesList.OfType<Desktop>())
                    {
                        if (desk.User == null)
                        {
                            Console.Write("| {0, -10}  ", "PC");
                            Console.Write("| {0, -8}  ", desk.Brand);
                            Console.Write("| {0, -11}  ", desk.Model);
                            Console.Write("| {0, -20} ", desk.Serial);
                            Console.Write("| {0, -10}{1, -10} ", "", "");
                            Console.WriteLine();
                        }
                    }
                }
            }
            Functions.PressAnyKey();
        }

        public static void ShowLookForDevices()
        {
            LookForDevices("número de serie");
        }
        public static List<IDevices> LookForDevices(string lookFor)
        {
            List<IDevices> foundDevices = new List<IDevices>();
            int count = 0;

            string sn;
            Functions.ShowTitle("Buscar por " + lookFor);
            Functions.Prompt("Ingrese el "+lookFor+" parcial o completo del dispositivo a buscar");
            sn = Console.ReadLine();
            Console.Clear();

            if (devicesList.OfType<Notebook>().FirstOrDefault() != null)
            {
                foreach (Notebook note in devicesList.OfType<Notebook>())
                {
                    if (note.Serial.Contains(sn.ToUpper()))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("| {0,-10}  | {1, -8}  | {2, -11}  | {3, -20} | {4, -20}  \n", "TIPO", "MARCA", "MODELO", "SERIAL", "USUARIO");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.Write("| {0, -10}  ", "Notebook");
                        Console.Write("| {0, -8}  ", note.Brand);
                        Console.Write("| {0, -11}  ", note.Model);
                        Console.Write("| {0, -20} ", note.Serial);
                        if (note.User != null)
                        {
                            Console.Write("| {0, -10}{1, -10} ", note.User.Name, note.User.LastName);
                        }
                        else
                        {
                            Console.Write("| {0, -10}{1, -10} ", "", "");
                        }
                        Console.WriteLine();
                        count++;
                        foundDevices.Add(note);
                        break;
                    }
                }
            }
            if (devicesList.OfType<Desktop>().FirstOrDefault() != null)
            {
                foreach (Desktop pc in devicesList.OfType<Desktop>())
                {
                    if (pc.Serial.Contains(sn.ToUpper()))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("| {0,-10}  | {1, -8}  | {2, -11}  | {3, -20} | {4, -20}  \n", "TIPO", "MARCA", "MODELO", "SERIAL", "USUARIO");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.Write("| {0, -10}  ", "Escritorio");
                        Console.Write("| {0, -8}  ", pc.Brand);
                        Console.Write("| {0, -11}  ", pc.Model);
                        Console.Write("| {0, -20} ", pc.Serial);
                        if (pc.User != null)
                        {
                            Console.Write("| {0, -10}{1, -10} ", pc.User.Name, pc.User.LastName);
                        }
                        else
                        {
                            Console.Write("| {0, -10}{1, -10} ", "", "");
                        }
                        Console.WriteLine();
                        count++;
                        foundDevices.Add(pc);
                        break;
                    }
                }
            }
            if (count == 0)
            {
                Functions.Error("No se pudo encontrar el " + lookFor);
            }
            else if (count >= 1)
            {
                Functions.Success($"¡Se han encontrado {count} registros!");
            }

            return foundDevices;
        }
        public static void ShowAddDevice()
        {
            int selection;
            string serial;

            Functions.ShowTitle("Cargar dispositivo");

            Functions.Prompt("¿Desea añadir una Notebook o una PC de escritorio?");
            Console.WriteLine("1. Notebook");
            Console.WriteLine("2. PC");
            Console.WriteLine("0. Cancelar");
            Int32.TryParse(Console.ReadLine(), out selection);
            switch (selection)
            {
                case 1:
                    Notebook nb = new Notebook();
                    Console.Clear();
                    Functions.ShowTitle("Cargar Notebook");

                    Functions.Prompt("Seleccione la marca de la Notebook");
                    nb.ReturnAvailableBrands();
                    Int32.TryParse(Console.ReadLine(), out selection);
                    while (selection != 0 && selection != 1 && selection != 2)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Cargar Notebook");

                        Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                        Functions.Prompt("Seleccione la marca de la Notebook");
                        nb.ReturnAvailableBrands();
                        Int32.TryParse(Console.ReadLine(), out selection);
                    }
                    nb.Brand = (NotebookBrands) selection;
                    Console.Clear();

                    Functions.ShowTitle("Cargar Notebook");
                    Functions.Prompt("Seleccione el modelo de la Notebook");
                    nb.ReturnAvailableModels();
                    Int32.TryParse(Console.ReadLine(), out selection);
                    while (selection != 0 && selection != 1 && selection != 2)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Cargar Notebook");

                        Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                        Functions.Prompt("Seleccione el modelo de la Notebook");
                        nb.ReturnAvailableBrands();
                        Int32.TryParse(Console.ReadLine(), out selection);
                    }
                    nb.Model = (NotebookModels)selection;
                    
                    Console.Clear();
                    Functions.ShowTitle("Cargar Notebook");
                    Functions.Prompt("Introduzca el número de serie de la Notebook");
                    serial = Console.ReadLine();
                    while (serial.Length != 8)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Cargar Notebook");

                        Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                        Functions.Prompt("Introduzca el número de serie de la Notebook");
                        serial = Console.ReadLine();
                    }
                    nb.Serial = serial.ToUpper();
                    devicesList.Add(nb);

                    Console.Clear();
                    Functions.ShowTitle("Cargar Notebook");
                    Console.WriteLine();
                    Functions.Success("Notebook cargada satisfactoriamente");
                    break;

                    case 2:
                    Desktop dp = new Desktop();
                    Console.Clear();
                    Functions.ShowTitle("Cargar PC");

                    Functions.Prompt("Seleccione la marca de la PC");
                    dp.ReturnAvailableBrands();
                    Int32.TryParse(Console.ReadLine(), out selection);
                    while (selection != 0 && selection != 1 && selection != 2)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Cargar PC");

                        Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                        Functions.Prompt("Seleccione la marca de la PC");
                        dp.ReturnAvailableBrands();
                        Int32.TryParse(Console.ReadLine(), out selection);
                    }
                    dp.Brand = (DesktopBrands)selection;
                    Console.Clear();

                    Functions.ShowTitle("Cargar PC");
                    Functions.Prompt("Seleccione el modelo de la PC");
                    dp.ReturnAvailableModels();
                    Int32.TryParse(Console.ReadLine(), out selection);
                    while (selection != 0 && selection != 1 && selection != 2)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Cargar PC");

                        Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                        Functions.Prompt("Seleccione el modelo de la PC");
                        dp.ReturnAvailableBrands();
                        Int32.TryParse(Console.ReadLine(), out selection);
                    }
                    dp.Model = (DesktopModels)selection;

                    Console.Clear();
                    Functions.ShowTitle("Cargar PC");
                    Functions.Prompt("Introduzca el número de serie de la PC");
                    serial = Console.ReadLine();
                    while (serial.Length != 8)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Cargar PC");

                        Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                        Functions.Prompt("Introduzca el número de serie de la PC");
                        serial = Console.ReadLine();
                    }
                    dp.Serial = serial.ToUpper();
                    devicesList.Add(dp);

                    Console.Clear();
                    Functions.ShowTitle("Cargar PC");
                    Functions.Success("PC cargada satisfactoriamente");
                    break;
                default:
                    break;
            }
        }
        public static void ShowModifyDevice()
        {
            List<IDevices> foundevices = new List<IDevices>();

            int count = 0;
            int response;
            string stResponse = "";
            int devicePos;
            Desktop dChosenDevice;
            Notebook nChosenDevice;

            foundevices = LookForDevices("Número de serie");
            Functions.PressAnyKey();
            Console.Clear();

            if (foundevices.Count() == 0)
            {
                Functions.Error("No se encontró ningún dispositivo, y por lo tanto no hay nada que modificar");
            }
            else
            {
                Functions.ShowTitle("Modificar dispositivo");
                Functions.Prompt("Seleccione el dispositivo a modificar");

                foreach (Notebook nb in foundevices.OfType<Notebook>())
                {
                    Console.WriteLine($"{devicesList.FindIndex(x => x == nb)}. {nb.Brand} {nb.Model} {nb.Serial}");
                    
                }

                foreach (Desktop pc in foundevices.OfType<Desktop>())
                {
                    Console.WriteLine($"{devicesList.FindIndex(x => x == pc)}. {pc.Brand} {pc.Model} {pc.Serial}");
                }

                Int32.TryParse(Console.ReadLine(), out response);
                while (response < 1 && response > count + 1)
                {
                    Functions.Error("La posición seleccionada no existe, ingrese un dato válido");

                    Functions.Prompt("Seleccione el dispositivo a modificar");
                    

                    Int32.TryParse(Console.ReadLine(), out response);
                }

                devicePos = response;
            
                if (devicesList[devicePos] is Notebook)
                {
                    nChosenDevice = (Notebook) devicesList[devicePos];

                    Console.Clear();
                    Functions.Prompt("¿Desea modificar la marca de la Notebook? Y/N");

                    if (Functions.ValidateConfirmation(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Modificar Notebook");
                        nChosenDevice.ReturnAvailableBrands();

                        Int32.TryParse(Console.ReadLine(), out response);
                        while (response != 0 && response != 1 && response != 2)
                        {
                            Console.Clear();
                            Functions.ShowTitle("Modificar Notebook");

                            Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                            Functions.Prompt("Seleccione la marca de la Notebook");
                            nChosenDevice.ReturnAvailableBrands();
                            Int32.TryParse(Console.ReadLine(), out response);
                        }
                        nChosenDevice.Brand = (NotebookBrands)response;
                        Console.Clear();
                    }

                    Console.Clear();
                    Functions.Prompt("¿Desea modificar el modelo de la Notebook? Y/N");
                    if (Functions.ValidateConfirmation(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Modificar Notebook");
                        nChosenDevice.ReturnAvailableModels();

                        Int32.TryParse(Console.ReadLine(), out response);
                        while (response != 0 && response != 1 && response != 2)
                        {
                            Console.Clear();
                            Functions.ShowTitle("Modificar Notebook");

                            Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                            Functions.Prompt("Seleccione el modelo de la Notebook");
                            nChosenDevice.ReturnAvailableBrands();
                            Int32.TryParse(Console.ReadLine(), out response);
                        }
                        nChosenDevice.Model = (NotebookModels)response;
                        Console.Clear();
                    }
                    Console.Clear();

                    Functions.ShowTitle("Modificar Notebook");
                    Functions.Prompt("¿Desea modificar el número de serie de la Notebook? Y/N");
                    if (Functions.ValidateConfirmation(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Modificar Notebook");
                        Functions.Prompt("Ingrese el nuevo número de serie: ");
                        stResponse = Console.ReadLine();

                        while (stResponse.Length != 8)
                        {
                            Console.Clear();
                            Functions.ShowTitle("Modificar Notebook");

                            Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                            Functions.Prompt("Ingrese el nuevo número de serie: ");
                            stResponse = Console.ReadLine();
                        }
                        nChosenDevice.Serial = stResponse;
                        Console.Clear();
                    }

                    devicesList[devicePos] = nChosenDevice;

                    Functions.Success("Dispositivo modificado satisfactoriamente");
                }
                if (devicesList[devicePos] is Desktop)
                {
                    dChosenDevice = (Desktop)devicesList[devicePos];

                    Console.Clear();
                    Functions.Prompt("¿Desea modificar la marca de la PC? Y/N");

                    if (Functions.ValidateConfirmation(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Modificar PC");
                        dChosenDevice.ReturnAvailableBrands();

                        Int32.TryParse(Console.ReadLine(), out response);
                        while (response != 0 && response != 1 && response != 2)
                        {
                            Console.Clear();
                            Functions.ShowTitle("Modificar PC");

                            Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                            Functions.Prompt("Seleccione la marca de la PC");
                            dChosenDevice.ReturnAvailableBrands();
                            Int32.TryParse(Console.ReadLine(), out response);
                        }
                        dChosenDevice.Brand = (DesktopBrands)response;
                        Console.Clear();
                    }

                    Console.Clear();
                    Functions.Prompt("¿Desea modificar el modelo de la PC? Y/N");
                    if (Functions.ValidateConfirmation(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Modificar PC");
                        dChosenDevice.ReturnAvailableModels();

                        Int32.TryParse(Console.ReadLine(), out response);
                        while (response != 0 && response != 1 && response != 2)
                        {
                            Console.Clear();
                            Functions.ShowTitle("Modificar PC");

                            Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                            Functions.Prompt("Seleccione el modelo de la PC");
                            dChosenDevice.ReturnAvailableBrands();
                            Int32.TryParse(Console.ReadLine(), out response);
                        }
                        dChosenDevice.Model = (DesktopModels)response;
                        Console.Clear();
                    }
                    Console.Clear();

                    Functions.ShowTitle("Modificar PC");
                    Functions.Prompt("¿Desea modificar el número de serie de la PC? Y/N");
                    if (Functions.ValidateConfirmation(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        Functions.ShowTitle("Modificar PC");
                        Functions.Prompt("Ingrese el nuevo número de serie: ");
                        stResponse = Console.ReadLine();

                        while (stResponse.Length != 8)
                        {
                            Console.Clear();
                            Functions.ShowTitle("Modificar PC");

                            Functions.Error("El valor ingresado es inválido, por favor, provea un dato válido");
                            Functions.Prompt("Ingrese el nuevo número de serie: ");
                            stResponse = Console.ReadLine();
                        }
                        dChosenDevice.Serial = stResponse;
                        Console.Clear();
                    }

                    devicesList[devicePos] = dChosenDevice;

                    Functions.Success("Dispositivo modificado satisfactoriamente");
                }
            }
        }

        public static void ShowDeleteDevice()
        {

        }

        /// <summary>
        /// previsualizar cada dispositivo de la lista mediante ToString
        /// </summary>
        public static void DebugDevices()
        {
            foreach (Notebook note in devicesList.OfType<Notebook>())
            {
                Console.WriteLine(note);
                Console.WriteLine(note.User);
            }
            foreach (Desktop desk in devicesList.OfType<Desktop>())
            {
                Console.WriteLine(desk);
                Console.WriteLine(desk.User);
            }
        }
    }
}