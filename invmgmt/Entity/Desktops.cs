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
        Bangho,
        Lenovo
    }

    public class Desktops : Devices
    {
        public DesktopBrands Brand { get; set; }
        public Desktops(DesktopBrands b, string s) : base(s)
        {
            Brand = b;
            Serial = s;
        }

    }
}
