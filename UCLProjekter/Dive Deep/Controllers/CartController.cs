using Dive_Deep.Data;
using Dive_Deep.Models;
using Dive_Deep.Services;
using Dive_Deep.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Dive_Deep.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly DiveDeepContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ProductSelectionService _productSelectionService;
        public CartController(DiveDeepContext context, UserManager<ApplicationUser> userManager, ProductSelectionService productSelectionService)
        {
            _context = context;
            _userManager = userManager;
            _productSelectionService = productSelectionService;
        }



        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge(); //-----------------------------------------------bruger skal være logget ind for at se sin kurv

            var cart = await _context.Carts  //---------------------------------------------------Hent cart, inkl. forbundne cartItem, og cartItems forbunde Product for den Cart med ApplicationUserId der matcher Id med bruger som er logget ind
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null)     //-------------------------------------------------------------------opret cart til brugeren i db hvis der ikke er en
            {
                return View(new CartViewModel());
            }

            var items = cart.Items.Select(i =>
            {
                string details = i.Product switch
                {
                    BCD bcd => $"Model: {bcd.Model}, Str.: {bcd.Sizes}",
                    DivingSuit suit => $"Model: {suit.Model}, Str.: {suit.Sizes}, Køn: {suit.Gender}, {suit.Thickness}mm",
                    Tank tank => $"{tank.Volume} L",
                    RegulatorSet reg => $"1. trin: {reg.FirstStep}, 2. trin: {reg.SecondStep}",
                    MaskSnorkel mask => $"Model: {mask.Model}",
                    Finns fins => $"Model: {fins.Model}, Str.: {fins.Sizes}",
                    _ => "Detaljer ikke tilgængelige"
                };

                return new CartItemViewModel
                {
                    CartItemId = i.CartItemId,
                    Brand = i.Product.Brand,
                    ProductType = i.Product.GetType().Name,
                    Details = details,
                    PricePerDay = i.Product.PricePerDay
                };
            }).ToList();

            var vm = new CartViewModel
            {
                Items = items,
                TotalPricePerDay = items.Sum(x => x.PricePerDay)
            };


            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
            int? selectedProductId,
            string? selectedSize,
            string? selectedGender,
            string? selectedThickness,
            int? representativeId,
            string? brand,
            string? model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            // Find eller opret cart
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { ApplicationUserId = user.Id };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            // RESOLVE productId
            int resolvedId = selectedProductId ?? 0;

            if (resolvedId == 0)
            {
                // Prøv at resolve via diving suit lookup (kræver brand+model+size+gender)
                if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model)
                    || string.IsNullOrWhiteSpace(selectedSize) || string.IsNullOrWhiteSpace(selectedGender))
                {
                    TempData["Error"] = "Du skal vælge alle nødvendige felter for at vælge en variant.";
                    return RedirectToAction("Details", "Products", new { id = representativeId ?? 0 });
                }

                // Kald ProductSelectionService (overload med primitive parametre)
                var id = await _productSelectionService.FindDivingSuitId(brand, model, selectedSize, selectedGender, selectedThickness);
                if (!id.HasValue)
                {
                    TempData["Error"] = "Kunne ikke finde en variant, der matcher dine valg.";
                    return RedirectToAction("Details", "Products", new { id = representativeId ?? 0 });
                }

                resolvedId = id.Value;
            }

            // Duplicate check
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == resolvedId);
            if (existingItem != null)
            {
                TempData["Error"] = "Produktet ligger allerede i din kurv.";
                return RedirectToAction("Details", "Products", new { id = representativeId ?? 0 });
            }

            // Tilføj item
            cart.Items.Add(new CartItem { ProductId = resolvedId, CartId = cart.CartId });
            await _context.SaveChangesAsync();

            TempData["Success"] = "Produkt tilføjet til kurv.";
            return RedirectToAction("Index", "Cart");
        }

        [HttpGet]
        public IActionResult Add(int productId)
        {
            if (productId == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Details", "Products", new {id =  productId});
        }




        public async Task<IActionResult> Remove(int itemId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null) return RedirectToAction("Index");            //viser index view. måske kan vi vise noget andet

            var item = cart.Items.FirstOrDefault(i => i.CartItemId == itemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}
