using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAppK209.Models
{
    public partial class Student
    {
        public Student()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Ssn { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
