using Service.Pattern;
using Solution.Data;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{

    public class ProjectService : Service<Project>,IProjectService


    {
        
        static IDataBaseFactory Factory = new DataBaseFactory();//l'usine de fabrication du context
        static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base
        public ProjectService() : base(utk)
        {


        }


        //Recherche
        public IEnumerable<Project> SearchProjectsByName(string searchString)
        {
            IEnumerable<Project> ProjectsDomain = GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                ProjectsDomain = GetMany(x => x.Titre.Contains(searchString));
            }


          

            return ProjectsDomain;
        }

       
        public Project GetProjectById(int id)
        {
            return utk.GetRepositoryBase<Project>().GetById(id);
        }
        public Project GetProjectById1(string currentUser)
        {
            return utk.GetRepositoryBase<Project>().GetById(currentUser);
        }
        public void EditProject(Project p)
        {
            utk.GetRepositoryBase<Project>().Update(p);
            utk.commit();
        }
       
        public List<Project> GetProjectById1()
        {
            return utk.GetRepositoryBase<Project>().GetMany().ToList();
        }

        public void AddProject(Project p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetPRojectAscending()
        {
            throw new NotImplementedException();
        }

        //public void CommitAddProject()
        //{
        //    uow.Commit();
        //}
    }





}
