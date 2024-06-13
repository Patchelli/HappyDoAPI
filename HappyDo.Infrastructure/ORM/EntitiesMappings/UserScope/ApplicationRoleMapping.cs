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
    public class ApplicationRoleMapping : BaseMapping, IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable(nameof(ApplicationRole), Schema);
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("id");

            builder.Property(r => r.Name).HasColumnType("varchar(250)").IsUnicode()
                   .HasColumnName("name").IsRequired();

            builder.Property(r => r.NormalizedName).HasColumnType("varchar(250)").IsUnicode()
                   .HasColumnName("normalized_name");

            builder.Property(r => r.ConcurrencyStamp).HasColumnName("concurrency_stamp");
        }
    }

}
