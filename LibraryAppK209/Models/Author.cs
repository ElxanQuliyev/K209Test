using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAppK209.Models
{
    public partial class Author
    {
        public Author()
        {
            AuthorToBooks = new HashSet<AuthorToBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorToBook> AuthorToBooks { get; set; }
    }
}
