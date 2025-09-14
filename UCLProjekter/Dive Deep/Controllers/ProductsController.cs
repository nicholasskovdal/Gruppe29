using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dive_Deep.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(string category)
        {
            var allProducts = ProductRepository.GetAll();
            IEnumerable<Product> products = allProducts;

            string title = "Products";                          //For displaying @Render title nicely;

            if (!string.IsNullOrEmpty(category))
            {
                products = category.ToLower() switch
                {
                    "bcd" => allProducts.OfType<BCD>(),
                    "divingsuit" => allProducts.OfType<DivingSuit>(),
                    "tank" => allProducts.OfType<Tank>(),
                    "regulatorset" => products.OfType<RegulatorSet>(),
                    "masksnorkel" => products.OfType<MaskSnorkel>(),
                    "finns" => allProducts.OfType<Finns>()
                };

                title = category.ToLower() switch               //Sætter title (string) til en kategori ud fra category input parameter som kommer fra knap i drowdown>_Layout
                {
                    "bcd" => "BCD",
                    "divingsuit" => "Dykkerdragter",
                    "tank" => "Tanke",
                };
            }
            ViewData["Title"] = title;
            return View(products);
        }
    }
}
