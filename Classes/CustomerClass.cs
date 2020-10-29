using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    public class CustomerClass
    {
        //private string _Name;
        //public string Name 
        //{
        //    get { return _Name; }
        //    set
        //    {
        //        _Name = value;
                
        //    } 
        //}
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public static CustomerClass[] customerList =
        {
            new CustomerClass { Name = "Lisa Underwood", Address = "Smallhill 7",    ZipCode = "215 70", City = "Malmö", Phone = "555-1967" },
            new CustomerClass { Name = "Olle Bull",      Address = "Djäknegatan 13", ZipCode = "215 71", City = "Malmö", Phone = "555-0344" },
            new CustomerClass { Name = "Ben Knota",      Address = "Stengränd 11",   ZipCode = "215 72", City = "Malmö", Phone = "555-4932" },
            new CustomerClass { Name = "Vilma Hypoxia",  Address = "Nikkaluokta",    ZipCode = "215 73", City = "Malmö", Phone = "555-3356" },
            new CustomerClass { Name = "Ken Barbie",     Address = "Dockgatan 3",    ZipCode = "215 74", City = "Malmö", Phone = "555-3282" }
        };

        
    }
}



