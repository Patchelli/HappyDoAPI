using HappyDo.Business.Interfaces.OthersContracts;
using HappyDo.Infrastructure.ORM.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.ORM.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseFacade _dbFacade;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _dbFacade = applicationContext.Database;
        }

        public void CommitTransaction()
        {
            try
            {
                _dbFacade.CommitTransaction();
            }
            catch
            {
                RolbackTransaction();
                throw;
            }
        }

        public void BeginTransaction() => _dbFacade.BeginTransaction();

        public void RolbackTransaction() => _dbFacade.RollbackTransaction();
    }

}
