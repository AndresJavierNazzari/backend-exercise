using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Exceptions;
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


    public IEnumerable<Category> GetCategories() {
        var categoryList = _context.Categories;

        NotFoundException.ThrowIfNull(categoryList);
        return categoryList;
    }

    public Category GetCategoryById(int categoryId) {
        var categoryList = _context.Categories;

        Category? category = categoryList.FirstOrDefault(c => c.Id == categoryId);
        NotFoundException.ThrowIfNull(category);

        return category;

    }
    //public static AddCategory(Category category) { }
}

