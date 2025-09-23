using Dive_Deep.Models;
namespace Dive_Deep.Persistence
{
    public interface IProductRepository
    {

        //Add. Asynchronous; the Task keyword represents an on-going operation that might take a while to finish. If there's no return type specified in Task<T>, it's like Void
        Task AddAsync(Product product);

        //Read
        Task<IEnumerable<Product>> GetAllAsync(); 
        Task<Product?> GetByIdAsync(int productId);
        Task<IEnumerable<T>> GetAllOfTypeAsync<T>() where T : Product; //Asynchronous GetAll of specified class that inherits from Product

        //Update
        Task UpdateAsync(Product product);

        //Delete
        Task DeleteAsync(int productId);

        //Get products in grouped categories to show in view
        Task<IEnumerable<Product>> GetGroupedProductsByCategory(string category);

    }
}
