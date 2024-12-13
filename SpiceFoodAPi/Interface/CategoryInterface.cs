﻿using SpiceS.Models;

namespace SpiceApi.Interface
{
    public interface CategoryInterface : IDisposable
    {
        Task CreateCategory(Category entity);
        Task<List<Category>> GetAllCategory();
        Task DeleteCategory(int Id);
        Task<Category> GetCategoryById(int Id);
        Task UpdateCategory(Category entity);
    }
}
