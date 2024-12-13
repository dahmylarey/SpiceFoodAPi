using Microsoft.AspNetCore.Mvc;
using SpiceApi.Repositories;
using SpiceS.Models;

namespace SpiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemRepository itemRepository;

        public MenuItemController(MenuItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }


        //all MenuItem
        [HttpGet]
        [Route("all-menuItem")]
        public async Task<IActionResult>AllMenuItems()
        {
            var response = await itemRepository.AllMenuItems();
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //By id
        [HttpGet]
        [Route("menuItemby-id")]
        public async Task<IActionResult>MenuItemById(int Id)
        {
            var response = await itemRepository.MenuItemById(Id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //New MenuItem
        [HttpPost]
        [Route("new-menuitem")]
        public async Task<IActionResult>CreateMenuItem(MenuItem entity)
        {
            await itemRepository.CreateMenuItem(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //Update MenuItem
        [HttpPut]
        [Route("edit-menuItem")]
        public async Task<IActionResult>EditMenuItem(MenuItem entity)
        {
            await itemRepository.EditMenuItem(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok();

        }

        //Delete Category
        [HttpDelete]
        [Route("delete-menuItem")]
        public async Task<IActionResult> DeleteMenuItem(int Id)
        {
            await itemRepository.DeleteMenuItem(Id);
            if (Id == null)
            {
                return NotFound();
            }

                return Ok();

        }
    }
}
