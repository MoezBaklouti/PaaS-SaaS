using MyFinance.Data.CustomConventions;
using Solution.Data.Configurations;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : DbContext
    {
        public static readonly object VoteVM;

        public MyContext() : base("name=mabase")
        {

        }
        // dbset
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Votee> Votees { get; set; }
        public static object SchoolVM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());
        }

      /*  public void SaveChanges()
        {
            throw new NotImplementedException();
        }*/


        /*
         public DbSet<DayOff> DayOff { get; set; }
         public DbSet<Holiday> Holiday { get; set; }
         public DbSet<InterMandate> InterMandate { get; set; }
         public DbSet<JobRequest> JobRequest { get; set; }
         public DbSet<Mandate> Mandate { get; set; }
         public DbSet<Message> Message { get; set; }
         public DbSet<Organigram> Organigram { get; set; }
         public DbSet<Request> Request { get; set; }
     }*/
    }
}
