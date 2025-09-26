using Dive_Deep.Models;

namespace Dive_Deep.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Representative { get; set; }
        public List<Product> Variants { get; set; } = new();
        public int SelectedProductId { get; set; }
        


        public List<string> Sizes { get; set; } = new();
        public List<string> Genders { get; set; } = new();
        public List<float?> Thicknesses { get; set; } = new();


        public string SelectedSize { get; set; }
        public string SelectedGender { get; set; }
        public string SelectedThickness { get; set; }

        public string RepresentativeSecondaryLabel { get; set; } = string.Empty;
        public string RepresentativeSecondaryValue { get; set; } = string.Empty;

    }
}
