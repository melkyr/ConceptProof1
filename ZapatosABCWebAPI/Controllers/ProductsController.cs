using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZapatosABCDataLibrary.Data;
using ZapatosABCDataLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZapatosABCWebAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class ProductsController : ControllerBase
    {

        private readonly IProductData _productData;
        public ProductsController(IProductData productData)
        {
            _productData = productData;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<ProductModel>> Get()
        {
            return await _productData.GetProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ProductModel> Get(int id)
        {
            return await _productData.GetProductById(id);
        }

    }
}
