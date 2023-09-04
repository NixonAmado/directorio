using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data;
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("phone_number");
            builder.Property(p => p.Number)
            .IsRequired()
            .HasMaxLength(30);
            
            builder.Property(p => p.PreFix)
            .IsRequired()
            .HasMaxLength(30);
    
            builder.HasOne(p => p.Person)
            .WithOne(p => p.PhoneNumber)
            .HasForeignKey<Person>(p => p.PhoneNumber);
            
        }
    }