﻿using Microsoft.AspNetCore.Mvc;
using SpiceApi.Interface;
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
        [Route("all-cate")]
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
        [Route("cateby-id")]
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
        [Route("new-cate")]
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
        [Route("update-cate")]
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
        [Route("Delete-categ")]
        public async Task<IActionResult>DeleteCategory(int Id)
        {
           await _categoryInterface.DeleteCategory(Id);
            
            return Ok();

        }



    }
}
