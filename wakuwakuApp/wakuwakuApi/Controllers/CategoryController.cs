using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using wakuwakuApi.Models;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "") {
            var categories = _categoryService.GetCategories(page, pageSize, filter);
            return Ok(categories);
        }

        /*
        // GET: CategoryController
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories(
            [FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "") {

            var paginatedCategories = categories.Skip((page - 1) * pageSize).Take(pageSize);

            if(!string.IsNullOrEmpty(filter)) {
                paginatedCategories =
                    paginatedCategories.Where(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)
                    || c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(paginatedCategories);
        }

         // TODO: GET By ID: CategoryController/5
        [HttpGet("{id}", Name = "Get Category")]
        public ActionResult<Category> GetCategory(int id) {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if(category == null) return NotFound();

            return Ok(category);
        }

        // TODO: POST: CategoryController
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category newCategory) {
            if(newCategory == null) return BadRequest("La categoría proporcionada es nula.");

            newCategory.Id = Category.GetNextId();

            categories.Add(newCategory);

            return CreatedAtRoute("GetCategory", new { id = newCategory.Id }, newCategory);
        }

        //TODO: PUT: CategoryController/5
        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, [FromBody] CategoryUpdate updatedCategory) {
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            if(existingCategory == null) return NotFound();

            existingCategory.Name = updatedCategory.Name;
            existingCategory.Description = updatedCategory.Description;

            return Ok(existingCategory);
        }

        // TODO: DELETE: CategoryController/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            if(existingCategory == null) return NotFound();

            categories.Remove(existingCategory);

            return NoContent();
        }

        */
    }
}
