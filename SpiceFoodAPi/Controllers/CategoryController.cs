using Microsoft.AspNetCore.Mvc;
using SpiceApi.Repositories;
using SpiceS.Models;

namespace SpiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
           
        }

        //all category
        [HttpGet]
        [Route("all-category")]
        public async Task<IActionResult>GetAllCategory(Category entity)
        {
            var response = await _categoryRepository.GetAllCategory(entity);
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
            var response = await _categoryRepository.GetCategoryById(id);
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
             await _categoryRepository.CreateCategory(entity);
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
            await _categoryRepository.UpdateCategory(entity);
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
           await _categoryRepository.DeleteCategory(id);
            
            return Ok();

        }



    }
}
