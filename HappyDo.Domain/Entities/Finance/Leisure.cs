using HappyDo.Domain.Entities.Finance.Transaction;
using HappyDo.Domain.Entities.UserRole;
using HappyDo.Domain.Entities.UserScope;

namespace HappyDo.Domain.Entities.Finance
{
    public class Leisure : OneTimeTransaction
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Leisure(ApplicationUser responsible, string description, decimal amount, DateTime dateTime)
            : base(description, amount, dateTime)
        {
            ApplicationUserId = responsible.Id;
            ApplicationUser = responsible;
        }
    }
}
