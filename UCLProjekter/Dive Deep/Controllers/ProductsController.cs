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
        private readonly DiveDeepContext _context;
        public ProductsController(DiveDeepContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string category)
        {
            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(category))
            {
                switch (category.ToLower())
                {
                    case "bcd":
                        products = _context.Products.OfType<BCD>();
                        break;
                    case "divingsuit":
                        products = _context.Products.OfType<DivingSuit>();
                        break;
                    case "tank":
                        products = _context.Products.OfType<Tank>();
                        break;
                    case "fins":
                        products = _context.Products.OfType<Finns>();
                        break;
                    case "mask":
                        products = _context.Products.OfType<MaskSnorkel>();
                        break;
                    case "regulator":
                        products = _context.Products.OfType<RegulatorSet>();
                        break;
                }
            }

            // Gruppér på Brand+Model så du kun får én per kort
            var grouped = await products
                .GroupBy(p => new { p.Brand})
                .Select(g => g.First())  // tager bare en repræsentant
                .ToListAsync();

            return View(grouped);
        }
    }
}
