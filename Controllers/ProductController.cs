using AutoMapper;
using PM_BLL;
using PM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagementSPA.Models;

namespace ProductManagementSPA.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method is to retrieve and display all the products that has been fetched to the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetProducts()
        {
            ProductService productService = new ProductService();
            var products = productService.GetProducts();

            List<ProductVM> productVMs = new List<ProductVM>();

            productVMs = Mapper.Map<List<Product>, List<ProductVM>>(products);

            return Json(productVMs, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Gets the product based off the productId using the HttpGet to handle the GET request
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetProductById(int productId)
        {
            ProductService productService = new ProductService();
            var product = productService.GetProductById(productId);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method allows us to add a product using Product product as my parameters and calling 
        /// the method from my ProductService class.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            ProductService productService = new ProductService();
            var productAdded = productService.AddProduct(product);
            return Json(productAdded, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the product by using the HttpPost to delete a product based off the productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            ProductService productService = new ProductService();
            if(productService.DeleteProduct(productId))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateProduct(Product product)
        {
            ProductService productService = new ProductService();
            var productUpdated = productService.UpdateProduct(product);
            return Json(productUpdated, JsonRequestBehavior.AllowGet);
        }

    }
}
