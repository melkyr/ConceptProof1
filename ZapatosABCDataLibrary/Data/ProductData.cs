using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapatosABCDataLibrary.DataAccess;
using ZapatosABCDataLibrary.Models;

namespace ZapatosABCDataLibrary.Data
{
    public class ProductData : IProductData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public ProductData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> CreateProduct(ProductModel product)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("ProductName", product.ProductName);
            p.Add("Price", product.Price);
            p.Add("Category", product.Category);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spProducts_Insert", p, _connectionString.SqlConnectionName);
            return p.Get<int>("Id");
        }

        public Task<int> UpdateProductName(int productId, string productName)
        {
            return _dataAccess.SaveData("dbo.spProducts_UpdateProductName", new { Id = productId, ProductName = productName }, _connectionString.SqlConnectionName);

        }

        public Task<int> DeleteProduct(int productId)
        {
            return _dataAccess.SaveData("dbo.spProducts_Delete", new { Id = productId }, _connectionString.SqlConnectionName);
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            var records = await _dataAccess.LoadData<ProductModel, dynamic>("dbo.spProducts_GetById", new { Id = productId }, _connectionString.SqlConnectionName);
            return records.FirstOrDefault();

        }

        public Task<List<ProductModel>> GetProducts()
        {
            return _dataAccess.LoadData<ProductModel, dynamic>("dbo.spProductsGetAll",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }
    }
}
