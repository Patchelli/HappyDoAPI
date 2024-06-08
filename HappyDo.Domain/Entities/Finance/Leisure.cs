using HappyDo.Domain.Entities.Finance.Transaction;

namespace HappyDo.Domain.Entities.Finance
{
    public class Leisure : OneTimeTransaction
    {
        public User Responsible { get; set; }

        public Leisure(User responsible, string description, decimal amount)
            : base(description, amount)
        {
            Responsible = responsible;
        }
    }
}
