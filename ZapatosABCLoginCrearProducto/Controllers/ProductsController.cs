using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZapatosABCDataLibrary.Data;
using ZapatosABCDataLibrary.DataAccess;
using ZapatosABCDataLibrary.Models;
using ZapatosABCLoginCrearProducto.Models;

namespace ZapatosABCLoginCrearProducto.Controllers
{
    public class ProductsController : Controller
    {
        private  ProductData _productData;

        public ProductsController()
        {
            
            
        }


        [Authorize]
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        // GET: Products/Create
        public async Task<ActionResult> Create(ProductData productData)
        {
            _productData = productData;
            ProductCreateModel newProduct = new ProductCreateModel();
            return View(newProduct);
        }


        [Authorize]
        [HttpPost]
        // GET: Products/Create
        public async Task<ActionResult> Create(ProductCreateModel newProduct)
        {
            if (ModelState.IsValid==false)
            {
                return View();

            }
            int id = await _productData.CreateProduct(newProduct.Product);

            return View();
        }

    }
}
