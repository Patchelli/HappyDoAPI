using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Enums;

namespace HappyDo.Domain.Entities.Finance
{
    public class Saving
    {
        public int SavingId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Saving()
        {
        }
    }
}
