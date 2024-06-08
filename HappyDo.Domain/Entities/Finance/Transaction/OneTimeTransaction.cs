namespace HappyDo.Domain.Entities.Finance.Transaction
{
    public class OneTimeTransaction : Transaction
    {
        public string Description { get; set; }

        public OneTimeTransaction(string description, decimal amount,DateTime dateTime)
            : base(amount,dateTime)
        {
            Description = description;
        }
    }

}
