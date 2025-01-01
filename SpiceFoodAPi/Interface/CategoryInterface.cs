using SpiceS.Models;

namespace SpiceApi.Interface
{
    public interface CategoryInterface : IDisposable
    {
        Task CreateCategory(Category entity);
        Task<IEnumerable<Category>> GetAllCategory(Category entity);
        Task<Category> DeleteCategory(int Id);
        Task<Category> GetCategoryById(int Id);
        Task UpdateCategory(Category entity);
    }
}
