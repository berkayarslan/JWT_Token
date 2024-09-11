using AutoMapper;
using System.Linq.Expressions;
using Web_Api_JWT.Models;
using Web_Api_JWT.Models.DTOs;
using Web_Api_JWT.Repo.Abstract;

namespace Web_Api_JWT.Repo.Concrete
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Create(CreateCategoryDTO cDto)
        {
            var category = _mapper.Map<Category>(cDto);
            _context.Categories.Add(category);
            if(_context.SaveChanges()>0)return true;
            return false;
        }


        public bool Delete(int id)
        {
            var category = _context.Categories.Find(id);
            category.Status = Enums.Status.Passive;
            if (_context.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        public List<Category> GetAllCategories(Expression<Func<Category, bool>> expression)
        {
           return _context.Categories.Where(expression).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public bool Update(UpdateCategoryDTO uDto)
        {
           var category = _mapper.Map<Category>(uDto);
            category.Status= Enums.Status.Modified;
            _context.Categories.Update(category);
            if (_context.SaveChanges()>0)
            {
                return true;
            }
            return false;
            
        }
    }
}
