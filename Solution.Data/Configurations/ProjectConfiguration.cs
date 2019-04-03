using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class ProjectConfiguration:EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            HasOptional(f=>f.User).WithMany(p => p.Projects)
                .HasForeignKey(f=>f.UserId)
                .WillCascadeOnDelete(false);
        }
        
    }
}
