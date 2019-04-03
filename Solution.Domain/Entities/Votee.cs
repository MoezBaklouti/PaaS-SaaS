using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Votee
    {
        [Key]
        public int AutoId { get; set; }
        public int SectionId { get; set; }
        public string VoteForId { get; set; }
        public string UserName { get; set; }
        public int Vote { get; set; }
        public string Active { get; set; }
    }
}
