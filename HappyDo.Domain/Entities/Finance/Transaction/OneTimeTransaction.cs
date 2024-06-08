namespace HappyDo.Domain.Entities.Finance.Transaction
{
    public class OneTimeTransaction : Transaction
    {
        public string Description { get; set; }

        public OneTimeTransaction(string description, decimal amount)
            : base(amount)
        {
            Description = description;
        }
    }

}
