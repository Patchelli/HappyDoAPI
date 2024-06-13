using HappyDo.Domain.Entities.ActionLoggerScope;
using HappyDo.Infrastructure.ORM.EntitiesMappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.ORM.EntitiesMappings.LoggerScope
{
    public sealed class UserLoggerMapping : BaseMapping, IEntityTypeConfiguration<UserLogger>
    {
        public UserLoggerMapping()
            : base(LoggerSchemaForMapping.LoggerSchema)
        {

        }

        public void Configure(EntityTypeBuilder<UserLogger> builder)
        {
            builder.ToTable(nameof(UserLogger), Schema);
            builder.HasKey(u => u.UserLoggerId);

            builder.Property(u => u.UserLoggerId).HasColumnName("id");

            builder.Property(u => u.ExecutorId).HasColumnType("uniqueidentifier")
                   .HasColumnName("executor_id").IsRequired();

            builder.Property(u => u.UpdatedUserId).HasColumnType("int")
                   .HasColumnName("updatedUser_id").IsRequired();

            builder.Property(u => u.LoggerAction).HasColumnType("tinyint")
                   .HasColumnName("logger_action").IsRequired();

            builder.Property(u => u.ExecutorRole).HasColumnType("varchar(50)").IsUnicode()
                   .HasColumnName("executor_role").IsRequired();

            builder.Property(u => u.ActionName).HasColumnType("varchar(100)").IsUnicode()
                   .HasColumnName("action_name").IsRequired();

            builder.Property(u => u.Reason).HasColumnType("varchar(200)").IsUnicode()
                   .HasColumnName("reason").IsRequired(false);

            builder.Property(u => u.ActionDate).HasColumnType("datetime2")
                   .HasColumnName("action_date").IsRequired();

            builder.HasOne(u => u.Executor)
                   .WithMany()
                   .HasForeignKey(u => u.ExecutorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

