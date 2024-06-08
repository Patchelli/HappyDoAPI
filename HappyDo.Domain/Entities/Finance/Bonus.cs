using HappyDo.Domain.Entities.Finance.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities.Finance
{
    public class Bonus : OneTimeTransaction
    {
        public User Responsible { get; set; }

        public Bonus(User responsible, string description, decimal amount)
            : base(description, amount)
        {
            Responsible = responsible;
        }
    }

}
