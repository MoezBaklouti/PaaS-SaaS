using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Data.CustomConventions
{
    public class DateTime2Convention:Convention
    {
        public DateTime2Convention()
        {
            Properties<DateTime>().Configure(e => e.HasColumnType("datetime2"));

            //toute les propriétes qui commence par le mot code en tant que clé primaire
           /* Properties<String>().Where(x => x.Name.StartsWith("code")).Configure(x => x.IsKey());*/
        }
    }
}
