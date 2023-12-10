using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Models;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpGet("{categoryId}")]
        public ActionResult<Category> GetCategoryById(int categoryId) {
            var category = _categoryService.GetCategoryById(categoryId);

            return Ok(category);
        }

        // POST: CategoryController
        [HttpPost(Name = "CreateCategory")]
        public ActionResult<Category> CreateCategory([FromBody] CategoryCreate categoryCreate) {
            var category = _categoryService.AddCategory(categoryCreate);

            return CreatedAtRoute("CreateCategory", new { id = category.Id }, category);
        }

        //  PUT: CategoryController/5
        [HttpPut("{categoryId}")]
        public ActionResult<Category> UpdateCategory(int categoryId, [FromBody] CategoryUpdate categoryUpdate) {
            var category = _categoryService.UpdateCategory(categoryId, categoryUpdate);

            return Ok(category);
        }

        // DELETE: CategoryController/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var deletedCategory = _categoryService.DeleteCategoryById(id);

            var response = new {
                message = $"Resource deleted: category {id}",
                deletedCategory
            };

            return Ok(response);
        }
    }
}
