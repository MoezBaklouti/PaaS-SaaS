using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Solution.Domain.Entities
{
    class SubcategoryViewModel
    {
        public HttpPostedFileBase PdfFile { get; set; }
        [DisplayName("PDF")]
        public string Pdf { get; set; }

    }
}
