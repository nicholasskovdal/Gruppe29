namespace Dive_Deep.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();
        public int TotalPricePerDay { get; set; }


        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
