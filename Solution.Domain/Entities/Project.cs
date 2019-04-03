using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Solution.Domain.Entities
{     public enum Branche
    {
        web,
        JEE,
        Net
    }
    public class Project
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime OutDate { get; set; }
        public string ImageUrl { get; set; }
        public Branche Branche { get; set; }
        public int? UserId { get; set; }
        //prop de navigation
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}
