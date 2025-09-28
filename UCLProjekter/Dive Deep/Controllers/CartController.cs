using Dive_Deep.Data;
using Dive_Deep.Models;
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
        public CartController(DiveDeepContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public async Task<IActionResult> Add(int productId) //------til Product/Details View, for at Post <form> til Cart
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { ApplicationUserId = user.Id};
                _context.Carts.Add(cart);
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if(existingItem != null)
            {
                return RedirectToAction("Index"); //----------------hvis produktet allerede er i kurven kan den ikke lægges i igen, der er kun 1. viser bare kurven hvis det sker
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = productId
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> Remove(int itemId)
        {
            var user = await _userManager.GetUserAsync (User);
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

            return RedirectToAction("Index");
        }
    }
}
