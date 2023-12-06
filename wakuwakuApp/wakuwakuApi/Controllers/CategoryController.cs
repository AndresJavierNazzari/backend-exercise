using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using wakuwakuApi.Models;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller {
        private static List<Category> categories = new List<Category> {
                new Category("Language", "Category related to languages."),
                new Category("Musical Instrument", "Category related to musical instruments."),
                new Category("Programming Language", "Category related to programming languages."),
                new Category("Sports", "Category related to sports."),
                new Category("Science", "Category related to scientific disciplines."),
                new Category("Art", "Category related to visual and performing arts."),
                new Category("History", "Category related to historical events and periods."),
                new Category("Technology", "Category related to technological advancements."),
                new Category("Travel", "Category related to travel and exploration."),
                new Category("Health", "Category related to health and wellness."),
                new Category("Fashion", "Category related to clothing and style."),
                new Category("Food", "Category related to culinary delights."),
                new Category("Education", "Category related to learning and academia."),
                new Category("Nature", "Category related to the natural world."),
                new Category("Entertainment", "Category related to entertainment and media."),
                new Category("Business", "Category related to commerce and entrepreneurship."),
                new Category("Hobbies", "Category related to personal interests and pastimes."),
                new Category("Fitness", "Category related to physical fitness and exercise."),
                new Category("Pets", "Category related to animals and pets."),
                new Category("Home and Garden", "Category related to home improvement and gardening.")
             };

        private readonly string connectionString;

        public CategoryController() {
            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
            var connectionStrings = appSettings.GetValue<string>("ConnectionStrings:WakuWakuAPIConnection");
            ArgumentException.ThrowIfNullOrEmpty(connectionStrings);
        }

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
