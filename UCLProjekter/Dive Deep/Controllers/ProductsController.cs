using Dive_Deep.Data;
using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Dive_Deep.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;


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

            switch (product)
            {
                case BCD bcd:
                    vm.RepresentativeSecondaryLabel = "Model";
                    vm.RepresentativeSecondaryValue = bcd.Model;
                    break;
                case DivingSuit divingSuit:
                    vm.RepresentativeSecondaryLabel = "Model";
                    vm.RepresentativeSecondaryValue = divingSuit.Model;
                    var suits = vm.Variants.OfType<DivingSuit>();
                    vm.Sizes = suits.Select(s => s.Sizes).Distinct().ToList();
                    vm.Genders = suits.Select(s => s.Gender).Distinct().ToList();
                    vm.Thicknesses = suits.Where(s => s.Thickness != null).Select(s => s.Thickness!).Distinct().ToList();
                    break;
                case Tank tank:
                    vm.RepresentativeSecondaryLabel = "Volumen";
                    vm.RepresentativeSecondaryValue = tank.Volume.ToString() + " liter";
                    break;
                case RegulatorSet regulatorSet:
                    vm.RepresentativeSecondaryLabel = "1. Trin";
                    vm.RepresentativeSecondaryValue = regulatorSet.FirstStep.ToString();
                    break;
                case MaskSnorkel maskSnorkel:
                    vm.RepresentativeSecondaryLabel = "Model";
                    vm.RepresentativeSecondaryValue = maskSnorkel.Model;
                    break;
                case Finns finns:
                    vm.RepresentativeSecondaryLabel = "Model";
                    vm.RepresentativeSecondaryValue = finns.Model;
                    break;
                default:
                    vm.RepresentativeSecondaryLabel = string.Empty;
                    vm.RepresentativeSecondaryValue = string.Empty;
                    break;
            }
            return View(vm);
        }
    }
}
