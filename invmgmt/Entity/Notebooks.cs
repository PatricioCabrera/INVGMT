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
            int count = 0;
            foreach ( string n in Enum.GetNames(typeof( NotebookBrands )))
            {
                Console.WriteLine( count +". " +n);
                count++;
            }
        }
        public override string ToString()
        {
            return $"{Model},{Brand},{Serial}, {UniqueID}";
        }

        public void ReturnAvailableModels()
        {
            int count = 0;
            foreach (string n in Enum.GetNames(typeof(NotebookModels)))
            {
                Console.WriteLine(count + ". " + n);
                count++;
            }

        }
    }
}
