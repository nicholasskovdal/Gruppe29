using System.ComponentModel.DataAnnotations;

namespace Dive_Deep.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }


        //Nav property
        public ICollection<ProductBooking> ProductBookings { get; set; }

    }   
}
