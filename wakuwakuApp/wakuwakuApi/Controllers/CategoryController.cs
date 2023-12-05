using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Models;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller {
        private static List<Category> categories = new List<Category> {
                new Category("Languaje", "Categoría relacionada con idiomas."),
                new Category("Musical instrument", "Categoría relacionada con instrumentos musicales."),
                new Category("Programming languaje", "Categoría relacionada con lenguajes de programación."),
                new Category("Sports", "Categoría relacionada con deportes.")
             };


        // GET: CategoryController
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() {

            return Ok(categories);
        }

        //GET: CategoryController/5
        [HttpGet("{id}", Name = "Get Category")]
        public ActionResult<Category> GetCategory(int id) {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if(category == null) return NotFound();

            return Ok(category);
        }

        // POST: CategoryController
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category newCategory) {
            if(newCategory == null) return BadRequest("La categoría proporcionada es nula.");

            newCategory.Id = Category.GetNextId();

            categories.Add(newCategory);

            return CreatedAtRoute("GetCategory", new { id = newCategory.Id }, newCategory);
        }

        //PUT: CategoryController/5
        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, [FromBody] CategoryUpdate updatedCategory) {
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            if(existingCategory == null) return NotFound();

            existingCategory.Name = updatedCategory.Name;
            existingCategory.Description = updatedCategory.Description;

            return Ok(existingCategory);
        }

        //DELETE: CategoryController/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var existingCategory = categories.FirstOrDefault(c => c.Id == id);
            if(existingCategory == null) return NotFound();

            categories.Remove(existingCategory);

            return NoContent();
        }
    }
}
