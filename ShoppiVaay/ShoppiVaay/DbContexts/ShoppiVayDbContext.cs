using Microsoft.EntityFrameworkCore;
using ShoppiVaay.Entities;

namespace ShoppiVaay.DbContexts;
public sealed class ShoppiVayDbContext : DbContext
{
    public ShoppiVayDbContext(DbContextOptions<ShoppiVayDbContext> options) : base(options) { }

    public DbSet<ProductEntity> Products { get; set; }
}
