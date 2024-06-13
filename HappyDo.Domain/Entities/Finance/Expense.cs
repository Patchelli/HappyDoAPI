using System.ComponentModel.DataAnnotations;
using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Enums;

namespace HappyDo.Domain.Entities.Finance
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ESituation Situation { get; set; }

        public Expense()
        {
        }
    }
}
