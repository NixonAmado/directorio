using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data;
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");
            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(30);
            
            builder.Property(p => p.SurName)
            .IsRequired()
            .HasMaxLength(30);
            
            builder.Property(p => p.Age)
            .IsRequired()
            .HasMaxLength(30);

            builder.HasOne(p => p.PhoneNumber)
            .WithOne(p => p.Person)
            .HasForeignKey<PhoneNumber>(p => p.Person);
            
        }
    }