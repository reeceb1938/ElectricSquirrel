using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Data.Models.Configurations
{
    public class EmployerConfiguiration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("Employers");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(e => e.Id)
                .IsUnique();

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
