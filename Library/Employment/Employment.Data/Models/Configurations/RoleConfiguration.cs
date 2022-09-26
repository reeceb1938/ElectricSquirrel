using Employment.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Data.Models.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(e => e.Employer)
                .WithMany(e => e.Roles);

            builder.Property(e => e.PayRate)
                .HasColumnName("PayRate")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(e => e.PayPeriod)
                .HasColumnName("PayPeriod")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasConversion(
                    v => v.ToString(),
                    v => (PayPeriod)Enum.Parse(typeof(PayPeriod), v))
                .IsRequired();

            builder.Property(e => e.PayType)
                .HasColumnName("PayType")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasConversion(
                    v => v.ToString(),
                    v => (PayType)Enum.Parse(typeof(PayType), v))
                .IsRequired();
        }
    }
}
