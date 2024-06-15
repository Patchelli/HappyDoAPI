using HappyDo.Domain.Entities.Activities;
using HappyDo.Domain.Entities.Finance;
using Microsoft.AspNetCore.Identity;

namespace HappyDo.Domain.Entities.UserScope
{
    public sealed class ApplicationUser : IdentityUser<Guid>
    {
        public User? User { get; set; }
        public required List<ApplicationUserRole> UserRoles { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string CPF { get; set; }
        public override string PhoneNumber { get; set; } = string.Empty;
        public List<Activity> Activities { get; set; } = new();
        public List<Expense> Expenses { get; set; } = new();
        public List<Income> Incomes { get; set; } = new();
        public Bonus? Bonus { get; set; }
        public Leisure? Leisure { get; set; }
        public Saving? Savings { get; set; }
    }

}
