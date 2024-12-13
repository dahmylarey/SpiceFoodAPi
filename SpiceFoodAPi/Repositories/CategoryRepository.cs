using Microsoft.EntityFrameworkCore;
using SpiceApi.Interface;
using SpiceFoodAPi.Data;
using SpiceS.Models;

namespace SpiceApi.Repositories
{
    public class CategoryRepository : CategoryInterface
    {
        private readonly SpiceFoodAPIDbContext _context;

        public CategoryRepository(SpiceFoodAPIDbContext context)
        {
            _context = context;
        }


        //Get all
        public async Task<List<Category>> GetAllCategory()
        {
            var allCategories = await _context.Categories.ToListAsync();

            return allCategories;
        }


        //Get By Id

        public async Task<Category> GetCategoryById(int Id)
        {
            return _context.Categories!.Where(o => o.Id == Id).FirstOrDefault()!;
        }


        //Craete
        public async Task CreateCategory(Category entity)
        {
            _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        //Delete
        public async Task DeleteCategory(int Id)
        {
            var existCategory = _context.Categories!.FindAsync(Id);
            _context.Remove(existCategory);
            await _context.SaveChangesAsync();

        }



        //Update
        public async Task UpdateCategory(Category entity)
        {
            
            _context.Categories!.Update(entity);

            await _context.SaveChangesAsync();

        }




        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
