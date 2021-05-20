using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryAppK209.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? BookId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? Price { get; set; }

        public virtual Book Book { get; set; }
        public virtual Student Student { get; set; }
    }
}
