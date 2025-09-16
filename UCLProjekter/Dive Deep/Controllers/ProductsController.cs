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
        public IActionResult Index(string category)
        {
            IQueryable<Product> products = _context.Products;

            if (!string.IsNullOrEmpty(category))
            {
                switch (category.ToLower())
                {
                    case "bcd":
                        products = _context.BCDs;
                        break;
                    case "divingsuit":
                        products = _context.BCDs;
                        break;
                    case "tank":
                        products = _context.Tanks;
                        break;
                    case "fins":
                        products = _context.Finns;
                        break;
                    case "mask":
                        products = _context.MaskSnorkels;
                        break;
                    case "regulator":
                        products = _context.RegulatorSets;
                        break;
                }
            }

            // Gruppér på Brand+Model så du kun får én per kort
            var grouped = await products
                .GroupBy(p => new { p.Brand, p.Model })
                .Select(g => g.First())  // tager bare en repræsentant
                .ToListAsync();

            return View(grouped);
        }
    }
}
