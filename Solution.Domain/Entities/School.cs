using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class School
    {
        [Key]
        public int AutoId { get; set; }
        public string Votes { get; set; }
    }
}
