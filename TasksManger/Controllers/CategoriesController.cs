using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace TasksManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            this._categoriesRepository = categoriesRepository;
        }

        [HttpGet("get")]
        public List<Categories> GetCategories()
        {
            return _categoriesRepository.GetAll();
        }

        [HttpGet("getById/{id}")]
        public ActionResult<Categories> GetCategoriesById(int id)
        {
            Categories categories = _categoriesRepository.GetById(id);
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }

        [HttpGet("getByName/{name}")]
        public ActionResult<List<Categories>> GetCategoriesByName(string name)
        {
            return _categoriesRepository.GetCategoriesByName(name);
        }

        [HttpPost("AddCategories")]
        public ActionResult<Categories> AdCategories(Categories newcategories)
        {
            if (newcategories == null || ModelState.IsValid)
                return BadRequest();

            Categories existingCategories = _categoriesRepository.GetById(newcategories.CategoriesId);

            if (existingCategories != null)
                return Conflict("Categories already exists.");
            _categoriesRepository.Add(newcategories);
            _categoriesRepository.SaveChanges();

            return CreatedAtAction(nameof(AdCategories), new { id = newcategories.CategoriesId }, newcategories);
        }

        [HttpPut("update/{id}")]
        public ActionResult<Categories> UpdateCategories(int id, Categories categories)
        {
            if (categories == null || !ModelState.IsValid)
                return BadRequest();
            if (id != categories.CategoriesId)
                return Conflict();
            _categoriesRepository.Update(categories);
            _categoriesRepository.SaveChanges();
            return Ok(categories);
        }
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCategories(int id)
        {
            Categories categories = _categoriesRepository.GetById(id);
            if (categories == null)
                return NotFound();//404
            _categoriesRepository.DeleteById(id);
            _categoriesRepository.SaveChanges();

            return NoContent();
        }
    }
}
