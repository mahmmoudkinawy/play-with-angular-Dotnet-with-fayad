using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ShoppiVaay.DbContexts;
using ShoppiVaay.Repositories;

namespace ShoppiVaay.Controllers;

[Route("api/products")]
[ApiController]
public sealed class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _productRepository.GetProductsAsync();

        return Ok(result);
    }

}
