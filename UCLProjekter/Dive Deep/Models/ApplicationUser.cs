using Microsoft.AspNetCore.Identity;

namespace Dive_Deep.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Booking>? Bookings { get; set; }
    }
}
