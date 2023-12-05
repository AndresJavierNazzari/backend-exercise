using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Entities;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller {
        private static Category[] categories =
            [
                new Category("Languaje", "Categoría relacionada con idiomas."),
                new Category("Musical instrument", "Categoría relacionada con instrumentos musicales."),
                new Category("Programming languaje", "Categoría relacionada con lenguajes de programación."),
                new Category("Sports", "Categoría relacionada con deportes.")
             ];

        // GET: CategoryController
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() {

            return Ok(categories);
        }

        // POST: CategoryController
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category newCategory) {
            if(newCategory == null) {
                return BadRequest("La categoría proporcionada es nula.");
            }

            // Agregar la nueva categoría al array
            var updatedCategories = categories.ToList();
            updatedCategories.Add(newCategory);
            categories = updatedCategories.ToArray();

            return CreatedAtAction(nameof(GetCategories), categories);
        }
    }
}
