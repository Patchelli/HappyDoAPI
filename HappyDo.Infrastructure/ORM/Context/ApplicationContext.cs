

using HappyDo.Domain.Entities.UserScope;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HappyDo.Infrastructure.ORM.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser,
                                                     ApplicationRole,
                                                     Guid,
                                                     IdentityUserClaim<Guid>,
                                                     ApplicationUserRole,
                                                     IdentityUserLogin<Guid>,
                                                     IdentityRoleClaim<Guid>,
                                                     IdentityUserToken<Guid>>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext)
            : base(dbContext)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging().EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }

}
