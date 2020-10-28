using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class CustomerClass
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        CustomerClass[] customerList =
            {
            new CustomerClass { name = "Lisa Underwood", address = "Smallhill 7", phone = "555-1967" },
            new CustomerClass { name = "Olle Bull", address = "Djäknegatan 13", phone = "555-0344" },
            new CustomerClass { name = "Ben Knota", address = "Stengränd 11", phone = "555-4932" },
            new CustomerClass { name = "Vilma Hypoxia", address = "Nikkaluokta", phone = "555-3356" },
            new CustomerClass { name = "Ken Barbie", address = "Dockgatan 3", phone = "555-3282" }
            };


    }
}



