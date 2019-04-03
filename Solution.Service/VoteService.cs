using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Data.Infrastructure;

namespace Solution.Service
{
    public class VoteService : Service<Votee>, IVoteService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();//l'usine de fabrication du context
        static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base
        public VoteService(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
