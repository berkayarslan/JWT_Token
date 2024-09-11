using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_JWT.Models.DTOs;
using Web_Api_JWT.Repo.Abstract;

namespace Web_Api_JWT.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categoryList = _categoryRepo.GetAllCategories(a=>a.Status!=Enums.Status.Passive);
            return Ok(categoryList);

        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepo.GetCategory(id);
            if (category!=null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (_categoryRepo.Create(dto)) return StatusCode(200);
                else return StatusCode(500, ModelState);
            }
            return BadRequest();
        }


        [HttpPut]
        public IActionResult UdateCategory ( UpdateCategoryDTO dto )
        {
            if (ModelState.IsValid)
            {
                if (_categoryRepo.Update(dto)) return Ok();
                else return BadRequest();

            }
            return BadRequest(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (_categoryRepo.Delete(id)) return Ok();
            return BadRequest();

        }
    }
}
