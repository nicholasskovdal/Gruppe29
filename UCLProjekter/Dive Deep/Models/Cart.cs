namespace Dive_Deep.Models
{
    public class Cart
    {

        public int CartId { get; set; }

        //Navigation Properties
        //public string? ApplicationUserId { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

    }
}
