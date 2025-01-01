using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SpiceApi.Interface;
using SpiceApi.Model;
using SpiceApi.Model.ViewModel;
using SpiceFoodAPi.Data;

namespace SpiceApi.Repositories
{
    public class SubCategoryRepository : SubCategoryInterface
    {
        private readonly SpiceFoodAPIDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public SubCategoryRepository(SpiceFoodAPIDbContext context)
        {
            _context = context;
        }


        //Get all  
        public async Task<List<SubCategory>> AllSubCategory(SubCategory entity)
        {
            return await _context.SubCategories.Include(s=>s.Category).ToListAsync();

            
        }


        //Get by Id  
        public async Task<SubCategory> SubCategoryById(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories = await (from SubCategory in _context.SubCategories where SubCategory.CategoryId == id.ToString() select SubCategory).ToListAsync();
            //return Json(new SelectList(subCategories, "Id", "Name"));
            return _context.SubCategories!.FirstOrDefault()!;
        }

        //Add new Sbcategory
        public async Task AddSubCategory(SubCategory entity)
        {
           var Addsub = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync();
            if (Addsub != null)
            {
                _context.SubCategories.Add(entity);
                await _context.SaveChangesAsync();
            }
        }

        //Delete
        public async Task<SubCategory> RemoveSubCategory(int Id)
        {
           var existSub = await _context.SubCategories!.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (existSub != null)
            {
                _context.SubCategories.Remove(existSub);
                await _context.SaveChangesAsync();
            }
            return existSub;
        }

        //update    
        public async Task UpdateSubCategory(SubCategory entity)
        {
            var subCateFromDb = await _context.SubCategories.FindAsync(entity.Id);
            subCateFromDb.Name = entity.Name;


            if (subCateFromDb != null) {
                _context.SubCategories.Update(subCateFromDb);
                await _context.SaveChangesAsync();
            
            }
                       
                       
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
