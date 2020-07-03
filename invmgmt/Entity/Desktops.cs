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
            foreach (int i in Enum.GetValues(typeof(DesktopBrands)))
                Console.WriteLine(i);
        }

        public void ReturnAvailableModels()
        {
            foreach (int i in Enum.GetValues(typeof(DesktopModels)))
                Console.WriteLine(i);
        }
    }
}
