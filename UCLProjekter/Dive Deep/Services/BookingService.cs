using Dive_Deep.Data;
using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dive_Deep.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly DiveDeepContext _context; //der skal oprettes CartRepository, CartItemRepository og ProductBookingsRepository for at afskaffe direkte _context her
        public BookingService(IBookingRepository bookingRepo, DiveDeepContext context)
        {
            _bookingRepo = bookingRepo;
            _context = context;
        }

        public async Task<(bool Success, string ErrorMessage)> TryCreateBookingAsync(ApplicationUser user, DateTime start, DateTime end)
        {
            if (start < DateTime.Now) return (false, "Starttidspunktet må ikke ligge i fortiden");

            if (end <= start) return (false, "Sluttidspunktet må ikke være før starttidspunktet");

            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);

            if (cart == null || !cart.Items.Any()) return (false, "Din kurv er tom. Tilføj noget for at booke");


            var productIds = cart.Items.Select(i => i.ProductId).ToList();

            var overlapping = await _context.ProductBookings
                .Include(pb => pb.Booking)
                .Where(pb => productIds.Contains(pb.ProductId) && !(end <= pb.Booking.StartTime || start >= pb.Booking.EndTime))
                .ToListAsync();

            if (overlapping.Any()) return (false, "Et eller flere produkter er allerede booket i den valgte periode");




            var booking = new Booking
            {
                StartTime = start,
                EndTime = end,
                ApplicationUserId = user.Id,
                ProductBookings = cart.Items.Select(ci => new ProductBooking {ProductId = ci.ProductId}).ToList()
            };

            await _bookingRepo.AddAsync(booking);
            _context.CartItems.RemoveRange(cart.Items);

            await _context.SaveChangesAsync();

            return (true, "Booking oprettet");
        }
    }
}
