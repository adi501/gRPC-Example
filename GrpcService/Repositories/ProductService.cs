
using GrpcService.DB;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Repositories
{
    public class ProductService : IProductService
    {  private readonly AppDbContext _appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            var result=_appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _appDbContext.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public Task<List<Product>> GetProductListAsync()
        {
           return _appDbContext.Products.ToListAsync();
        }
    }
}
