using Employment.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Data.Models.Configurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Shifts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id);

            builder.HasOne(e => e.Employer)
                .WithMany(e => e.Shifts);

            builder.HasOne(e => e.Role)
                .WithMany(e => e.Shifts);

            builder.Property(e => e.RoleName)
                .HasColumnName("RoleName")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

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

            builder.Property(e => e.StartDateTime)
                .HasColumnName("StartDateTime")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(e => e.EndDateTime)
                .HasColumnName("EndDateTime")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(e => e.BreakInMinutes)
                .HasColumnName("BreakInMinutes")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.RecordedStartDateTime)
                .HasColumnName("RecordedStartDateTime")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(e => e.RecordedEndDateTime)
                .HasColumnName("RecordedEndDateTime")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(e => e.RecordedBreakInMinutes)
                .HasColumnName("RecordedBreakInMinutes")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.IsProspective)
                .HasColumnName("IsProspective")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
