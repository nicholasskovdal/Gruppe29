using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dive_Deep.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public BookingsController(IBookingRepository bookingRepo, IProductRepository productRepo, UserManager<ApplicationUser> userManager)
        {
            _bookingRepo = bookingRepo;
            _productRepo = productRepo;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                var bookings = (await _bookingRepo.GetAllAsync()).ToList();
                return View(bookings);
            }
            else
            {
                var userId = user.Id.ToString();
                var bookings = (await _bookingRepo.GetAllAsync())
                    .Where(b => b.ApplicationUserId == userId)
                    .ToList();
                return View(bookings);
            }
        }
    }
}
