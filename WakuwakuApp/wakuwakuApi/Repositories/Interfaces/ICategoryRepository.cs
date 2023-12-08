using wakuwakuApi.Models;

namespace wakuwakuApi.Repositories.Interfaces {
    public interface ICategoryRepository {

        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category AddCategory(CategoryCreate categoryCreate);
        Category UpdateCategory(int categoryId, CategoryUpdate categoryUpdate);
        Category DeleteCategoryById(int categoryId);
    }
}
