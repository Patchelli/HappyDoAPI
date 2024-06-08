using HappyDo.Domain.Entities.Finance.Transaction;

namespace HappyDo.Domain.Entities.Finance
{
    public class Savings : OneTimeTransaction
    {
        public User Owner { get; set; }

        public Savings(User responsible, string description, decimal amount)
            : base(description, amount)
        {
            Owner = responsible;
        }
    }

}
