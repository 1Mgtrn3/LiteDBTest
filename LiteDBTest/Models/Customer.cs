using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteDBTest.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }
}
