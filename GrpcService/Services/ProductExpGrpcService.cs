using Grpc.Core;
using GrpcService.Repositories;
using ProductExpService;

namespace GrpcService.Services
{
    public class ProductExpGrpcService : ProductExp.ProductExpBase
    {
        private readonly ILogger<ProductExpGrpcService> _logger;
        private readonly IProductService _productService;
        public ProductExpGrpcService(ILogger<ProductExpGrpcService> logger,IProductService productService)
        {
            _logger = logger;
            _productService= productService;
        }
        public override async Task<Products> GetProductList(Empty empty, ServerCallContext context)
        {
            List<Product> products = new List<Product>();

            products = await _productService.GetProductListAsync();
            Products response = new Products();
            foreach (Product pro in products)
            {
                ProductDetail objProductDetail = new ProductDetail();
                objProductDetail.Id=pro.Id;
                objProductDetail.Name = pro.Name;
                objProductDetail.Price = pro.Price;
                response.Items.Add(objProductDetail);
            }
            return response;

        }
        //public async GetProduct()
        //{

        //}
        //public async CreateProduct()
        //{

        //}
    }
}
