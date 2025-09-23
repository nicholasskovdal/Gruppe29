using Dive_Deep.Data;
using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Dive_Deep.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }



        public async Task<IActionResult> Index(string category)
        {
            var products = await _productRepo.GetGroupedProductsByCategory(category);
            return View(products);
        }


    }
}
