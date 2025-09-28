using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Dive_Deep.Services;
using Dive_Deep.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Dive_Deep.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BookingService _bookingService;

        public BookingsController(IBookingRepository bookingRepo, IProductRepository productRepo, UserManager<ApplicationUser> userManager, BookingService bookingService)
        {
            _bookingRepo = bookingRepo;
            _productRepo = productRepo;
            _userManager = userManager;
            _bookingService = bookingService;
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

        public async Task<IActionResult> Add(CartViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            var result = await _bookingService.TryCreateBookingAsync(user,   model.StartTime ?? DateTime.MinValue,    model.EndTime ?? DateTime.MinValue);

            if (!result.Success)
            {
                TempData["Error"] = result.ErrorMessage;
                return RedirectToAction("Index", "Cart");
            }

            TempData["Success"] = "Booking oprettet!";
            return RedirectToAction("Index", "Bookings");
        }
    }
}
