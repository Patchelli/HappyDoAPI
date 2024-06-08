using HappyDo.Domain.Entities.Finance.Transaction;
using HappyDo.Domain.Entities.UserRole;
using HappyDo.Domain.Entities.UserScope;

namespace HappyDo.Domain.Entities.Finance
{
    public class Savings : OneTimeTransaction
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Savings(ApplicationUser owner, string description, decimal amount, DateTime dateTime)
            : base(description, amount, dateTime)
        {
            ApplicationUserId = owner.Id;
            ApplicationUser = owner;
        }
    }

}
