using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.Entity
{
    public enum DesktopBrands
    {
        ASUS,
        Acer,
        Lenovo
    }

    public enum DesktopModels
    {
        WorkStation,
        Compacta,
        Micro
    }

    public class Desktop : Devices, IDevices
    {
        public DesktopBrands Brand { get; set; }
        public DesktopModels Model { get; set; }
        public User User { get; set; }
        public Desktop(DesktopBrands b, string s) : base(s)
        {
            Brand = b;
            Serial = s;
        }
        public Desktop() : base()
        {
        }

        public void ReturnAvailableBrands()
        {
            int count = 0;
            foreach (string n in Enum.GetNames(typeof(DesktopBrands)))
            {
                Console.WriteLine(count + ". " + n);
                count++;
            }
        }

        public void ReturnAvailableModels()
        {
            int count = 0;
            foreach (string n in Enum.GetNames(typeof(DesktopModels)))
            {
                Console.WriteLine(count + ". " + n);
                count++;
            }
        }
    }
}
