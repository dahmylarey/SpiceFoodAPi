using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _context.Categories.ToListAsync(),
                SubCategory = new SubCategory(),
                SubCategoryList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync(),
                StatusMessage = StatusMessage

            };
            _context.SubCategories.Add(model.SubCategory);
            await _context.SaveChangesAsync();
        }

        //Delete
        public async Task RemoveSubCategory(int Id)
        {
            var existSubCate = _context.SubCategories!.FindAsync(Id);
            _context.Remove(existSubCate);
            await _context.SaveChangesAsync();
        }

        //update    
        public async Task UpdateSubCategory(SubCategory entity)
        {
            var subCateFromDb = await _context.SubCategories.FindAsync(entity.Id);
            subCateFromDb.Name = entity.Name;



            //bool saved = false;
            //_context.SubCategories!.Update(entity);

            _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
