using wakuwakuApi.Models;

namespace wakuwakuApi.Repositories.Interfaces {
    public interface ICategoryRepository {

        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);

    }
}
