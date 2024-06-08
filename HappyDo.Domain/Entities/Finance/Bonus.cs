using HappyDo.Domain.Entities.Finance.Transaction;
using HappyDo.Domain.Entities.UserRole;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities.Finance
{
    public class Bonus : OneTimeTransaction
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Bonus(ApplicationUser responsible, string description, decimal amount ,DateTime dateTime)
            : base(description, amount ,dateTime)
        {
            ApplicationUserId = responsible.Id;
            ApplicationUser = responsible;
        }
    }
}
