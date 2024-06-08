using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Business.Interfaces.OthersContracts
{
    public interface IUnitOfWork
    {
        void CommitTransaction();
        void RolbackTransaction();
        void BeginTransaction();
    }

}
