using HappyDo.Domain.Entities.UserRole;
using HappyDo.Domain.Enums;

namespace HappyDo.Domain.Entities.UserScope
{
    public sealed class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public EUserStatus UserStatus { get; set; }

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public List<Task> Tasks { get; set; } = new();
    }


}
