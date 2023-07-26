namespace ShoppiVaay.Entities;
public sealed class ProductEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? Price { get; set; }
}
