using Grpc.Core;
using Product;

namespace InventoryAPI.Services
{
    public class ProductCatalogService : ProductCatalog.ProductCatalogBase
    {
        public override Task<ProductDetailsReply> GetProductDetails(ProductDetailsRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ProductDetailsReply
            {
                Id = request.Id,
                Name = "Purple Bowtie",
                Sku = "purbow",
                Price = new Price
                {
                    Amount = 100,
                    CurrencyCode = "USD"
                }
            });
        }
    }
}