using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Assignment.Domain.Model;

namespace Assignment.Infra.Data.Configuration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(350);

            builder.HasData(
                new Unit() { Id = 1, Name = "Kilo" },
                new Unit() { Id = 2, Name = "box" },
                new Unit() { Id = 3, Name = "can" },
                new Unit() { Id = 4, Name = "liter" },
                new Unit() { Id = 5, Name = "bottle" }
            );
        }
    }
}
