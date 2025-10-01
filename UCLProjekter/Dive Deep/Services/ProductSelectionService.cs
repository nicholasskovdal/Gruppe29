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

        public async Task<int?> FindDivingSuitId(string brand, string model, string size, string gender, string? thickness)
        {
            var suit = await _productRepo.FindMatchingDivingSuitAsync(brand, model, size, gender, thickness);
            return suit?.ProductId;
        }

    }
}
