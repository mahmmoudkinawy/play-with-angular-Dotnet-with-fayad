using Bogus;
using Microsoft.EntityFrameworkCore;
using ShoppiVaay.Entities;

namespace ShoppiVaay.DbContexts;
public class Seed
{
    public static async Task SeedProductsAsync(ShoppiVayDbContext context)
    {
        if (await context.Products.AnyAsync())
        {
            return;
        }

        var products = new Faker<ProductEntity>()
            .RuleFor(c => c.Name, f => "test")
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
            .RuleFor(c => c.Color, f => f.Commerce.Color())
            .RuleFor(c => c.ImageUrl, f => f.Person.Avatar)
            .RuleFor(c => c.Price, f => Convert.ToDecimal(f.Commerce.Price()))
            .Generate(300);

        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }
}
