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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(w => w.Person)
                .HasForeignKey(x => x.Id);
        }
    }
}
