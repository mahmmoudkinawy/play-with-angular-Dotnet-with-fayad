using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using ShoppiVaay.DbContexts;
using ShoppiVaay.Entities;

namespace ShoppiVaay.Repositories;
public sealed class ProductRepository : IProductRepository
{
    private readonly ShoppiVayDbContext _context;

    public ProductRepository(ShoppiVayDbContext context)
    {
        _context = context;
    }

    public async Task AddProduct(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public Task<ProductEntity> GetProductByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<ProductEntity>> GetProductsAsync()
    {
        return await _context.Products.FromSqlRaw("SELECT * FROM Products;")
            .ToListAsync(); ;   // SELECT * FROM Products;
    }

    public Task RemoveProduct(ProductEntity product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProduct(ProductEntity product)
    {
        throw new NotImplementedException();
    }
}
