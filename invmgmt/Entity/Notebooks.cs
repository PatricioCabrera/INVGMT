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

    public class Notebook : Devices, IDevices
    {
        public NotebookModels Model { get; set; }
        public NotebookBrands Brand { get; set; }
        public User User { get; set; }
        public Notebook(NotebookModels m, NotebookBrands b, string sn) : base ( sn)
        {
            Model = m;
            Brand = b;
            Serial = sn;
        }
        public Notebook() : base()
        {

        }
        public void ReturnAvailableBrands()
        {
            foreach ( int i in Enum.GetValues(typeof( NotebookBrands )) )
                Console.WriteLine(i);
        }
        public override string ToString()
        {
            return $"{Model},{Brand},{Serial}, {UniqueID}";
        }

        public void ReturnAvailableModels()
        {
            foreach (int i in Enum.GetValues(typeof(NotebookModels) ))
                Console.WriteLine(i);
        }
    }
}
