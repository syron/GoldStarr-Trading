using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class CustomerClass
    {
        public CustomerClass(string name, string address, string zipCode, string city, string phone)
        {
            Name = name;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public void GetCustomerInfo()
        {
            throw new System.NotImplementedException();
        }


    }
}



