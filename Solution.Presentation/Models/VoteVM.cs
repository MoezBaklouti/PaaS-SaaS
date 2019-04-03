using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class VoteVM
    {
        public int id { get; set; }
        public int SectionId { get; set; }
        public string VoteForId { get; set; }
        public string UserName { get; set; }
        public int Vote { get; set; }
        public string Active { get; set; }

       
    }
}