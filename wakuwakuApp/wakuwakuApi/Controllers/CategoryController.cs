using Asp.Versioning;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Models;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : ControllerBase {

        private IValidator<CategoryCreate> _validator;
        private readonly ICategoryService _categoryService;

        public CategoryController(IValidator<CategoryCreate> validator, ICategoryService categoryService) {
            _validator = validator;
            _categoryService = categoryService;
        }

        // GET: /Category
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Category>> GetCategories([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "") {
            var categories = _categoryService.GetCategories(page, pageSize, filter);
            return Ok(categories);
        }
        // GET: /Category/{categoryId}
        [HttpGet("{categoryId}")]
        [HttpHead]
        public ActionResult<Category> GetCategoryById(int categoryId) {
            var category = _categoryService.GetCategoryById(categoryId);

            return Ok(category);
        }

        // POST: /Category
        [HttpPost(Name = "CreateCategory")]
        public ActionResult<Category> CreateCategory([FromBody] CategoryCreate categoryCreate) {
            ValidationResult result = _validator.Validate(categoryCreate);

            if(!result.IsValid) {
                return BadRequest(result.Errors[0].ErrorMessage);
            }

            var category = _categoryService.AddCategory(categoryCreate);
            return CreatedAtRoute("CreateCategory", new { id = category.Id }, category);
        }

        //  PUT: /Category/{categoryId}
        [HttpPut("{categoryId}")]
        public ActionResult<Category> UpdateCategory(int categoryId, [FromBody] CategoryUpdate categoryUpdate) {
            var category = _categoryService.UpdateCategory(categoryId, categoryUpdate);

            return Ok(category);
        }

        // DELETE: /Category/{categoryId}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var deletedCategory = _categoryService.DeleteCategoryById(id);

            var response = new {
                message = $"Resource deleted: category {id}",
                deletedCategory
            };

            return Ok(response);
        }

        // OPTIONS: /Category
        [HttpOptions]
        public IActionResult OptionsCategory() {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");
            return Ok();
        }
    }
}
