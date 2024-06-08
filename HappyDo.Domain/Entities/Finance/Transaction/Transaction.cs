namespace HappyDo.Domain.Entities.Finance.Transaction
{
    public class Transaction
    {
        public decimal Amount { get; set; }

        public Transaction(decimal amount)
        {
            Amount = amount;
        }
    }

}
