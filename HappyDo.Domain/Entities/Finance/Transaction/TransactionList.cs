namespace HappyDo.Domain.Entities.Finance.Transaction
{
    using System.Collections.Generic;

    public class TransactionList
    {
        public List<OneTimeTransaction> Transactions { get; set; }

        public TransactionList()
        {
            Transactions = new List<OneTimeTransaction>();
        }
    }

}
