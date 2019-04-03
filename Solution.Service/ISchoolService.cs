using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    interface ISchoolService:IService<School>
    {   void AddSchool(School s);
        School GetSchoolById(int id);
        School GetSchoolById1(string currentUser);
        IEnumerable<School> GetSchoolAscending();
        List<School> GeSchoolById1();
        void CommitAddProject();
        void SaveChanges();

    }
}
