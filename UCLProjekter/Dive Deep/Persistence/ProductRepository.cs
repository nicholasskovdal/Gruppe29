using Dive_Deep.Models;
using System.Threading.Tasks;

namespace Dive_Deep.Persistence
{
    public class ProductRepository : IProductRepository
    {
        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllOfTypeAsync<T>() where T : Product
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
