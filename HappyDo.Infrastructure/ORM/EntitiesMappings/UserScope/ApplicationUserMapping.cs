using HappyDo.Domain.Entities.UserScope;
using HappyDo.Infrastructure.ORM.EntitiesMappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.ORM.EntitiesMappings.UserScope
{
    public class ApplicationUserMapping : BaseMapping, IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(nameof(ApplicationUser), Schema);
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("id");

            builder.Property(a => a.UserName).HasColumnName("login");

            builder.Property(a => a.PasswordHash).HasColumnName("password");

            builder.Property(a => a.Email).HasColumnName("email");

            builder.Property(a => a.EmailConfirmed).HasColumnName("email_confirmed");

            builder.Property(a => a.PhoneNumber).HasColumnName("cell_phone");

            builder.Property(a => a.PhoneNumberConfirmed).HasColumnName("cell_phone_confirmed");

            builder.Property(a => a.AccessFailedCount).HasColumnName("access_failed_count");

            builder.Property(a => a.NormalizedEmail).HasColumnName("normalized_email");

            builder.Property(a => a.NormalizedUserName).HasColumnName("normalized_login");

            builder.Property(a => a.LockoutEnabled).HasColumnName("lockout_enabled");

            builder.Property(a => a.ConcurrencyStamp).HasColumnName("concurrency_stamp");

            builder.Property(a => a.SecurityStamp).HasColumnName("security_stamp");

            builder.Property(a => a.TwoFactorEnabled).HasColumnName("two_factor_enabled");

            builder.HasOne(a => a.User)
                   .WithOne(u => u.ApplicationUser)
                   .HasForeignKey<User>(u => u.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
