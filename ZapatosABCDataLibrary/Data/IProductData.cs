using System.Collections.Generic;
using System.Threading.Tasks;
using ZapatosABCDataLibrary.Models;

namespace ZapatosABCDataLibrary.Data
{
    public interface IProductData
    {
        Task<int> CreateProduct(ProductModel product);
        Task<int> DeleteProduct(int productId);
        Task<ProductModel> GetProductById(int productId);
        Task<int> UpdateProductName(int productId, string productName);
        Task<List<ProductModel>> GetProducts();
    }
}