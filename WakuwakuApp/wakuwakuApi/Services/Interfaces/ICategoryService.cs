using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wakuwakuApi.Models;

namespace wakuwakuApi.Services.Interfaces {
    public interface ICategoryService {
        IEnumerable<Category> GetCategories(int page, int pageSize, string filter);
        Category GetCategoryById(int categoryId);
        Category AddCategory(CategoryCreate categoryCreate);
        Category UpdateCategory(int categoryId, CategoryUpdate categoryUpdate);
        Category DeleteCategoryById(int categoryId);
    }
}
