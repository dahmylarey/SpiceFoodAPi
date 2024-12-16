using Microsoft.AspNetCore.Mvc;
using SpiceApi.Interface;
using SpiceApi.Model;
using SpiceFoodAPi.Data;

namespace SpiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly SubCategoryInterface _subCategoryInterface;
        private readonly SpiceFoodAPIDbContext _db;

        public SubCategoryController(SubCategoryInterface subCategoryInterface, SpiceFoodAPIDbContext db)
        {
            _subCategoryInterface = subCategoryInterface;
            _db = db;
        }

        [HttpGet]
        [Route("all-subcategory")]
        public async Task<IActionResult>AllSubCategory(SubCategory entity)
        {
            var response = await _subCategoryInterface.AllSubCategory(entity);
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
            var response = await _subCategoryInterface.SubCategoryById(Id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //New SubCategory
        [HttpPost]
        [Route("new-category")]
        public async Task<IActionResult>AddSubCategory(SubCategory entity)
        {
            await _subCategoryInterface.AddSubCategory(entity);
            if (entity == null)
            {
                return NotFound();
            }



            return Ok(entity);
        }

        //Update SuCategory
        [HttpPut]
        [Route("update-subcategory")]
        public async Task<IActionResult>UpdateSubCategory(SubCategory entity)
        {
            await _subCategoryInterface.UpdateSubCategory(entity);
            if (entity == null)
            {
                return NotFound();
            }

            
            return Ok(entity);

        }

        //Remove SubCategory
        [HttpDelete]
        [Route("remove-subcategory")]
        public async Task<IActionResult>RemoveSubCategory(int Id)
        {
            await _subCategoryInterface.RemoveSubCategory(Id);
            if (Id == null)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
