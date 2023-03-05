using Microsoft.EntityFrameworkCore;
using SixPack.Domain.Entity;
using SixPack.Domain.Repositories;

namespace SixPack.Infrastructure
{
    public class SixPackDB : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProdcutImage> ProdcutImages { get; set; }

        public SixPackDB(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SixPackDB).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}