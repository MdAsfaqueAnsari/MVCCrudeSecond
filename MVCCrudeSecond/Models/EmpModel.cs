using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrudeSecond.Models
{
    public class EmpModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Mob { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}