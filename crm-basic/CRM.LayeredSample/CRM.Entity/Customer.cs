using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity
{
    public class Customer : BaseType
    {
        public Customer()
        {
            this.CreateDate = DateTime.Now;
           
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool? Gender { get; set; } 
        public string PhotoPath { get; set; }
        
    }
}
