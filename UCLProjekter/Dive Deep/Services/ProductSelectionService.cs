using Dive_Deep.Persistence;
using Dive_Deep.ViewModels;

namespace Dive_Deep.Services
{
    public class ProductSelectionService
    {
        private readonly IProductRepository _productRepo;
        public ProductSelectionService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<int?> FindDivingSuitId(ProductDetailsViewModel vm)
        {
            var suit = await _productRepo.FindMatchingDivingSuitAsync(
                vm.Representative.Brand,
                vm.RepresentativeSecondaryValue,
                vm.SelectedSize,
                vm.SelectedGender,
                vm.SelectedThickness);
            return suit?.ProductId;
        }

    }
}
