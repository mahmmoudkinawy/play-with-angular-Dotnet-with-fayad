using ShoppiVaay.Entities;

namespace ShoppiVaay.Repositories;
public interface IProductRepository
{
    Task<IReadOnlyList<ProductEntity>> GetProductsAsync();
    Task<ProductEntity> GetProductByIdAsync(int productId);
    Task AddProduct(ProductEntity product);
    Task UpdateProduct(ProductEntity product);
    Task RemoveProduct(ProductEntity product);
}
