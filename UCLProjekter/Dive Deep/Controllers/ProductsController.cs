using Dive_Deep.Data;
using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Dive_Deep.ViewModels;
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


        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            
            var variants = await _productRepo.GetAllProductsInSameGroup(product);


            var vm = new ProductDetailsViewModel
            {
                Representative = product,
                Variants = variants.ToList()
            };
            return View(vm);
        }
    }
}
