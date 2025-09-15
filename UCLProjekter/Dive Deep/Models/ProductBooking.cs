namespace Dive_Deep.Models
{
    public class ProductBooking
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
