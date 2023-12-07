using Microsoft.AspNetCore.Mvc.RazorPages;
using wakuwakuApi.Models;
using wakuwakuApi.Persistence.Interfaces;
using wakuwakuApi.Repositories.Interfaces;

namespace wakuwakuApi.Repositories;

public class CategoryRepository : ICategoryRepository {

    private readonly IInMemoryPersistenceService _context;

    public CategoryRepository(IInMemoryPersistenceService context) {
        ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }


    public IEnumerable<Category> GetCategories(int page = 1, int pageSize = 10, string filter = "") {
        var categoryList = _context.Categories;

        return categoryList;
    }
    //public static GetCategorieById() { }
    //public static AddCategory(Category category) { }
}

