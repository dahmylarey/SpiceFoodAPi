﻿using Microsoft.EntityFrameworkCore;
using SpiceApi.Interface;
using SpiceFoodAPi.Data;
using SpiceS.Models;

namespace SpiceApi.Repositories
{
    public class MenuItemRepository : MenuItemInterface
    {
        private readonly SpiceFoodAPIDbContext _context;

        public async Task<List<MenuItem>> AllMenuItems(MenuItem entity)
        {
            var menuItems = await _context.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync();
            return menuItems;
        }

        public async Task CreateMenuItem(MenuItem entity)
        {

          var create =  _context.MenuItem.AddAsync(entity);
            if (create != null)
            {
                _context.MenuItem.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
                          
        }

        public async Task DeleteMenuItem(int Id)
        {
           var deln = await _context.MenuItem!.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (deln != null)
            {
                _context.MenuItem.Remove(deln);
                await _context.SaveChangesAsync();
            }
        }

        
        public async Task EditMenuItem(MenuItem entity)
        {
            _context.MenuItem!.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task <MenuItem> MenuItemById(int Id)
        {
            var itemById = _context.MenuItem!.Include(m => m.Category).Include(m => m.SubCategory).FirstOrDefault();
            _context.Remove(Id);
            await _context.SaveChangesAsync();
            return itemById;

        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
