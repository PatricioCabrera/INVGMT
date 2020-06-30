using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.Entity
{
    public class Users
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UniqueID { get; set; }
        public Notebooks Notebook { get; set; }
        public Desktops Desktop { get; set; }
        public List<Notebooks> ListNotebook{get; set;}
        public List<Desktops> ListDesktop { get; set; }

        public Users(string n, string l)
        {
            Name = n;
            LastName = l;
            UniqueID = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"{Name},{UniqueID}";
        }
        public void ShowNotebook()
        {
            Console.WriteLine($"{Notebook.Brand}, {Notebook.Model}, {Notebook.Serial}");
        }

        public void ShowDesktop()
        {
            Console.WriteLine($"{Desktop.Brand}, {Notebook.Serial}");
        }
    }
}
