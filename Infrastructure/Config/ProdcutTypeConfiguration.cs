
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SixPack.Domain.Entity;

namespace SixPack.Infrastructure.Config
{
    public class ProdcutTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Images)
                .WithOne();

        }
    }
}
