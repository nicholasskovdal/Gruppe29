namespace Dive_Deep.ViewModels
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public int PricePerDay { get; set; }
    }
}
