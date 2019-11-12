using System;
using System.Threading.Tasks;

namespace server
{
    class ProductImpl : ProductService.ProductServiceBase
    {
        public override Task<Product> GetProductById(ProductByIdRequest request, Grpc.Core.ServerCallContext context)
        {
            Console.WriteLine($"{nameof(ProductService)} | {nameof(GetProductById)} | Request: {request.ProductId}");
            if (request.ProductId == 1)
            {
                return Task.FromResult(new Product
                {
                    ProductId = 1,
                    ProductUuid = "Id Of Product 1"
                });
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public override Task<Product> GetProductByUuid(ProductByUuidRequest request, Grpc.Core.ServerCallContext context)
        {
            Console.WriteLine($"{nameof(ProductService)} | {nameof(GetProductByUuid)} | Request: {request.ProductUuid}");
            if (request.ProductUuid == "Id Of Product 1")
            {
                return Task.FromResult(new Product
                {
                    ProductId = 1,
                    ProductUuid = "Id Of Product 1"
                });
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
