using day4.Models;

namespace day4.Interface
{
    public interface IProductRepo
    {
        Task <IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<int> CreateProduct(Product product);
        Task <int> UpdateProduct(Product product);
        Task <int> DeleteProduct(int id); 
    }
}
