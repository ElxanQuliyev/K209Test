using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAppK209.Models
{
    
    public partial class Book
    {
        public Book()
        {
            AuthorToBooks = new HashSet<AuthorToBook>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AuthorToBook> AuthorToBooks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
