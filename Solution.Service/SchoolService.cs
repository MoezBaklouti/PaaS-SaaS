using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Solution.Domain.Entities;
using Service.Pattern;
using Solution.Data.Infrastructure;

namespace Solution.Service
{
    public class SchoolService : Service<School>, ISchoolService
    {

        static IDataBaseFactory Factory = new DataBaseFactory();//l'usine de fabrication du context
        static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base

        public SchoolService(IUnitOfWork utk) : base(utk)
        {
        }

        public void Add(School entity)
        {
            throw new NotImplementedException();
        }

        public void AddSchool(School s)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void CommitAddProject()
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<School, bool>> Condition)
        {
            throw new NotImplementedException();
        }

        public void Delete(School entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<School> GeSchoolById1()
        {
            throw new NotImplementedException();
        }

        public School Get(Expression<Func<School, bool>> Condition)
        {
            throw new NotImplementedException();
        }

        public School GetById(string id)
        {
            throw new NotImplementedException();
        }

        public School GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<School> GetMany(Expression<Func<School, bool>> Condition = null, Expression<Func<School, bool>> OrderBy = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<School> GetSchoolAscending()
        {
            throw new NotImplementedException();
        }

        public School GetSchoolById(int id)
        {
            throw new NotImplementedException();
        }

        public School GetSchoolById1(string currentUser)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(School entity)
        {
            throw new NotImplementedException();
        }
    }
}
