using SpiceApi.Model;


namespace SpiceApi.Interface
{
    public interface SubCategoryInterface : IDisposable
    {

        Task AddSubCategory(SubCategory entity);
        Task<List<SubCategory>> AllSubCategory();
        Task RemoveSubCategory(int Id);
        Task<SubCategory> SubCategoryById(int Id);
        Task UpdateSubCategory(SubCategory entity);
    }
}
