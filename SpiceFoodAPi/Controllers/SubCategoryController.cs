using Microsoft.AspNetCore.Mvc;

using SpiceApi.Model;
using SpiceApi.Repositories;
using SpiceFoodAPi.Data;

namespace SpiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly SubCategoryRepository subCategory;
        private readonly SpiceFoodAPIDbContext _db;

        public SubCategoryController(SubCategoryRepository subCategory, SpiceFoodAPIDbContext _db)
        {
            this.subCategory = subCategory;
            this._db = _db;
        }


        [HttpGet]
        [Route("all-subcategory")]
        public async Task<IActionResult>AllSubCategory()
        {
            var response = await subCategory.AllSubCategory();
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //By id
        [HttpGet]
        [Route("subcategoryby-id")]
        public async Task<IActionResult>SubCategoryById(int Id)
        {
            var response = await subCategory.SubCategoryById(Id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(Id);
        }

        //New SubCategory
        [HttpPost]
        [Route("new-category")]
        public async Task<IActionResult>AddSubCategory(SubCategory entity)
        {
            await subCategory.AddSubCategory(entity);
            if (entity == null)
            {
                return NotFound();
            }



            return Ok();
        }

        //Update SuCategory
        [HttpPut]
        [Route("update-subcategory")]
        public async Task<IActionResult>UpdateSubCategory(SubCategory entity)
        {
            await subCategory.UpdateSubCategory(entity);
            if (entity == null)
            {
                return NotFound();
            }

            
            return Ok();

        }

        //Remove SubCategory
        [HttpDelete]
        [Route("remove-subcategory")]
        public async Task<IActionResult>RemoveSubCategory(int Id)
        {
            await subCategory.RemoveSubCategory(Id);
            if (Id == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
