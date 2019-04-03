using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Domain.Entities;
using System.ComponentModel;

namespace Solution.Presentation.Models
{
    public enum BrancheVM
    {
        web,
        JEE,
        Net
    }
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime OutDate { get; set; }
        public string ImageUrl { get; set; }
        public BrancheVM Branche { get; set; }
        [Display(Name = "User")]
        public int? UserId { get; set; }
       
        public IEnumerable<SelectListItem> Users { get; set; }

        public static explicit operator ProjectVM(BrancheVM v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator ProjectVM(Branche v)
        {
            throw new NotImplementedException();
        }
    }
}