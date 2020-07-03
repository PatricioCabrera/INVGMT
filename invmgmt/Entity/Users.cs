using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invmgmt.Entity
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UniqueID { get; set; }
        public Notebook Notebook { get; set; }
        public Desktop Desktop { get; set; }
        public List<Notebook> ListNotebook{get; set;}
        public List<Desktop> ListDesktop { get; set; }

        public User(string n, string l)
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
