namespace HappyDo.Domain.Entities.Finance.Transaction
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount, DateTime dateTime)
        {
            Amount = amount;
            Date = dateTime;
        }
    }

}
