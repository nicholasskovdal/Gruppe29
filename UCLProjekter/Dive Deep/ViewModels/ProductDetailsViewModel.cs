using Dive_Deep.Models;

namespace Dive_Deep.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Representative { get; set; }
        public List<Product> Variants { get; set; } = new List<Product>();
    }
}
