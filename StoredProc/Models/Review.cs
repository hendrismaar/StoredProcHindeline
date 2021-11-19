using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoredProc.Models
{
    public class Review
    {
        [Key]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
    }
}
