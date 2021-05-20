using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAppK209.Models
{
    public partial class AuthorToBook
    {
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public int? BookId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
