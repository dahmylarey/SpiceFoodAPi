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
        public async Task<IEnumerable<Category>> GetAllCategory(Category entity)
        {
            await _context.Categories.ToListAsync();

            return _context.Categories;

        }


        //Get By Id

        public async Task<Category> GetCategoryById(int Id)
        {
             var cate = await _context.Categories!.FindAsync(Id);
            if (cate != null)
            {
                return cate;
            }

            return new Category();
        }


        //Craete
        public async Task CreateCategory(Category entity)
        {
            _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        //Delete
        public async Task<Category> DeleteCategory(int Id)
        {
            var deln = await _context.Categories!.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (deln != null)
            {
                _context.Categories.Remove(deln);
                await _context.SaveChangesAsync();

            }
            return deln!;

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
