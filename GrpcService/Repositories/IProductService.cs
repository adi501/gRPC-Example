using System;

namespace GrpcService.Repositories
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<Product> GetProductByIdAsync(int Id);
        public Task<Product> AddProductAsync(Product product);
    }
}
