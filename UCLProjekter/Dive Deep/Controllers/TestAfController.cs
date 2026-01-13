using Dive_Deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Dive_Deep.Controllers
{
    
    public class TestAfController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public TestAfController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IActionResult> Index()
        {
            var bookingsList = await _bookingRepository.GetAllAsync();
            return View(bookingsList);
        }
    }
}
