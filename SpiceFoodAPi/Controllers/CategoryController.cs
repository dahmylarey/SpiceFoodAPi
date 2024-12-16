using Microsoft.AspNetCore.Mvc;
using SpiceApi.Interface;
using SpiceApi.Repositories;
using SpiceS.Models;

namespace SpiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryInterface _categoryInterface;
        

        public CategoryController(CategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
           
        }

        //all category
        [HttpGet]
        [Route("all-category")]
        public async Task<IActionResult>GetAllCategory(Category entity)
        {
            var response = await _categoryInterface.GetAllCategory(entity);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //By id
        [HttpGet]
        [Route("get-category-by-id")]
        public async Task<IActionResult>GetCategoryById(int id)
        {
            var response = await _categoryInterface.GetCategoryById(id);
            if (response==null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //New Category
        [HttpPost]
        [Route("new-category")]
        public async Task<IActionResult>CreateCategory(Category entity)
        {
             await _categoryInterface.CreateCategory(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }


        //Update Category
        [HttpPut]
        [Route("Edit-category")]
        public async Task<IActionResult>UpdateCategory(Category entity)
        {
            await _categoryInterface.UpdateCategory(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }

        //Delete Category
        [HttpDelete]
        [Route("Delete-category")]
        public async Task<IActionResult>DeleteCategory(int id)
        {
           await _categoryInterface.DeleteCategory(id);
            
            return Ok();

        }



    }
}
