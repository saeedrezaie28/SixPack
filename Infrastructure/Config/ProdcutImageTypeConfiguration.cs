
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SixPack.Domain.Entity;

namespace SixPack.Infrastructure.Config
{
    public class ProdcutImageTypeConfiguration : IEntityTypeConfiguration<ProdcutImage>
    {
        public void Configure(EntityTypeBuilder<ProdcutImage> builder)
        {
            builder.Property(a => a.ID)
                .UseHiLo("ProdcutImages_sequence");
            
        }
    }
}
