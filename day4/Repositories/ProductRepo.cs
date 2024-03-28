using day4.Interface;
using day4.Models;
using Microsoft.EntityFrameworkCore;

namespace day4.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly Day4Context db;
        // Day4Context db2 = new Day4Context(); 
        public ProductRepo(Day4Context db)
        {
            this.db = db;
        }
        public async Task<int> CreateProduct(Product product)
        {
            db.Products.Add(product);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await db.Products.FindAsync(id); 
            db.Products.Remove(product); 
            return await db.SaveChangesAsync(); 
        }

        public Task<Product> GetProduct(int id)
        {
            var product = db.Products.SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await db.Products.ToListAsync();
            return products;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var oldProduct = await GetProduct(product.Id);
            if (oldProduct != null) 
            {
                oldProduct.Price = product.Price;
                oldProduct.Name = product.Name;
                oldProduct.Image = product.Image;
                return await db.SaveChangesAsync();
            }
            return -1;
        }
    }
}
