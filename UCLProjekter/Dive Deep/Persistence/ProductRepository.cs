using Dive_Deep.Data;
using Dive_Deep.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dive_Deep.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly DiveDeepContext _context;
        public ProductRepository(DiveDeepContext context)
        {
            _context = context;
        }

        
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllOfTypeAsync<T>() where T : Product
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }


        
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }


        
        public async Task DeleteAsync(int productId)
        {
            var product = await GetByIdAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetGroupedProductsByCategory(string category)
        {
            category = category.ToLower();

            switch (category)
            {
                case "bcd":
                    return await _context.Set<BCD>()
                        .GroupBy(b => new { b.Brand, b.Model })
                        .Select(g => g.First())
                        .ToListAsync();
                case "divingsuit":
                    return await _context.Set<DivingSuit>()
                        .GroupBy(d => new { d.Brand, d.Model })
                        .Select(g => g.First())
                        .ToListAsync();
                case "masksnorkel":
                    return await _context.Set<MaskSnorkel>()
                        .GroupBy(m => new { m.Brand, m.Model })
                        .Select(g => g.First())
                        .ToListAsync();
                case "finns":
                    return await _context.Set<Finns>()
                        .GroupBy(f => new { f.Brand, f.Model })
                        .Select(g => g.First())
                        .ToListAsync();
                case "tank":
                    return await _context.Set<Tank>()
                        .GroupBy(t => new { t.Brand, t.Volume })
                        .Select(g => g.First())
                        .ToListAsync();
                case "regulatorset":
                    return await _context.Set<RegulatorSet>()
                        .GroupBy(r => new { r.Brand, r.FirstStep })
                        .Select(g => g.First())
                        .ToListAsync();
            }
            return new List<Product>();
        }
    }
}
