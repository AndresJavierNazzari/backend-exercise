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
        var categoryList = _context.Categories ?? throw new Exception();
        NotFoundException.ThrowIfNull(categoryList);

        return categoryList;
    }

    public Category GetCategoryById(int categoryId) {
        var categoryList = _context.Categories;

        Category? category = categoryList.FirstOrDefault(c => c.Id == categoryId);

        NotFoundException.ThrowIfNull(category);

        return category;
    }

    public Category AddCategory(CategoryCreate categoryCreate) {
        var categoryList = _context.Categories;

        Category createdCategory = new Category(categoryCreate.Name, categoryCreate.Description);

        categoryList.Add(createdCategory);

        return createdCategory;
    }

    public Category UpdateCategory(int categoryId, CategoryUpdate categoryUpdate) {
        var categoryList = _context.Categories;
        Category? existingCategory = categoryList.FirstOrDefault(c => c.Id == categoryId);
        NotFoundException.ThrowIfNull(existingCategory);

        existingCategory.Name = categoryUpdate.Name;
        existingCategory.Description = categoryUpdate.Description;

        return existingCategory;
    }

    public Category DeleteCategoryById(int categoryId) {
        var categoryList = _context.Categories;
        Category? category = categoryList.FirstOrDefault(c => c.Id == categoryId);

        NotFoundException.ThrowIfNull(category);
        categoryList.Remove(category);

        return category;
    }

}

