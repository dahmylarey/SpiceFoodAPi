using Microsoft.AspNetCore.Mvc;
using SpiceApi.Interface;
using SpiceS.Models;

namespace SpiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemInterface _menuItemInterface;

        public MenuItemController(MenuItemInterface menuItemInterface)
        {
            _menuItemInterface = menuItemInterface;
        }




        //all MenuItem
        [HttpGet]
        [Route("all-menuItem")]
        public async Task<IActionResult>AllMenuItems(MenuItem entity)
        {
            var response = await _menuItemInterface.AllMenuItems(entity);
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
            var response = await _menuItemInterface.MenuItemById(Id);
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
            await _menuItemInterface.CreateMenuItem(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        //Update MenuItem
        [HttpPut]
        [Route("edit-menuItem")]
        public async Task<IActionResult>EditMenuItem(MenuItem entity)
        {
            await _menuItemInterface.EditMenuItem(entity);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);

        }

        //Delete Category
        [HttpDelete]
        [Route("delete-menuItem")]
        public async Task<IActionResult> DeleteMenuItem(int Id)
        {
            await _menuItemInterface.DeleteMenuItem(Id);
            if (Id == null)
            {
                return NotFound();
            }

                return Ok();

        }
    }
}
