namespace HappyDo.Domain.Entities
{
    public class User
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string PhoneNumber { get; set; } 
        public decimal TotalRecurringValue { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }

}
