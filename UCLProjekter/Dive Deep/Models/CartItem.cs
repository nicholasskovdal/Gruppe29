namespace Dive_Deep.Models
{
    public class CartItem
    {

        public int CartItemId { get; set; }


        //Navigation Properties: Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //Navigation Properties: Cart
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
