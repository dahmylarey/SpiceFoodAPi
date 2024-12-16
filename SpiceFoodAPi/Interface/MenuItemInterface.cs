using SpiceApi.Model;
using SpiceS.Models;

namespace SpiceApi.Interface
{
    public interface MenuItemInterface : IDisposable
    {
        Task CreateMenuItem(MenuItem entity);
        Task<List<MenuItem>>AllMenuItems(MenuItem entity);
        Task DeleteMenuItem(int Id);
        Task <MenuItem>MenuItemById(int Id);
        Task EditMenuItem(MenuItem entity);
    }
}
