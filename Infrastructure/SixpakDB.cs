using Microsoft.EntityFrameworkCore;
using SixPack.Domain;

namespace SixPack.Infrastructure
{
    public class SixPackDB : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProdcutImage> ProdcutImages { get; set; }

        public SixPackDB(DbContextOptions options) : base(options)
        {
        }
    }
}