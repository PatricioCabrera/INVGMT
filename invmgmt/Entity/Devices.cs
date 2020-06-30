using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.Entity
{
    public abstract class Devices
    {
        public string UniqueID { get; set; }
        public string Serial { get; set; }



        public Devices()
        {
            UniqueID = Guid.NewGuid().ToString();
        }
        public Devices( string s)
        {
            UniqueID = Guid.NewGuid().ToString();
            Serial = s;
        }


    }
}
