using System.Linq.Expressions;
using Web_Api_JWT.Models;
using Web_Api_JWT.Models.DTOs;

namespace Web_Api_JWT.Repo.Abstract
{
    public interface ICategoryRepo
    {
        bool Create(CreateCategoryDTO cDto);
        Category GetCategory(int id);
        List<Category> GetAllCategories(Expression<Func<Category,bool>>expression);
        bool Update(UpdateCategoryDTO uDto);
        bool Delete(int id);

    }
}
