using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserType)
                .WithMany(o => o.User)
                .HasForeignKey(f => f.IdUserType);

            builder.HasOne(x => x.UserStatus)
                .WithMany(o => o.User)
                .HasForeignKey(f => f.IdUserStatus);
        }
    }
}
