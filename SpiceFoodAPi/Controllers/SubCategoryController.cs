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

        public SubCategoryController(SubCategoryInterface subCategoryInterface)
        {
            _subCategoryInterface = subCategoryInterface;
        }

        [HttpGet]
        [Route("all-subcat")]
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
        [Route("subcateby-id")]
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
        [Route("new-subcate")]
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
        [Route("update-subcate")]
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
        [Route("remove-subcate")]
        public async Task<IActionResult>RemoveSubCategory(int Id)
        {
            await _subCategoryInterface.RemoveSubCategory(Id);
            
            return Ok();

        }
    }
}
