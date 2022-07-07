using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
