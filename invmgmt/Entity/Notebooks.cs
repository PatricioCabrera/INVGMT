using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.Entity
{
    public enum NotebookModels
    {
        ZenBook,
        Bes,
        ThinkPad
    }

    public enum NotebookBrands
    {
        ASUS,
        Banghó,
        Lenovo
    }

    public class Notebooks : Devices
    {
        public NotebookModels Model { get; set; }
        public NotebookBrands Brand { get; set; }
        public Notebooks(NotebookModels m, NotebookBrands b, string sn) : base ( sn)
        {
            Model = m;
            Brand = b;
            Serial = sn;
        }

        public override string ToString()
        {
            return $"{Model},{Brand},{Serial}, {UniqueID}";
        }
    }
}
