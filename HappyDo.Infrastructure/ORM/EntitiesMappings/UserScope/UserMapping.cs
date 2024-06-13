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
    public sealed class UserMapping : BaseMapping, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User), Schema);
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId).HasColumnName("id");

            builder.Property(u => u.ApplicationUserId).HasColumnName("applicationUser_id");

            builder.Property(u => u.Name).HasColumnType("varchar(150)").IsUnicode()
                   .HasColumnName("name").IsRequired();

            builder.Property(u => u.UserStatus).HasColumnType("tinyint")
                   .HasColumnName("user_status").IsRequired();

        }
    }

}
