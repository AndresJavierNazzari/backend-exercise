using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using wakuwakuApi.Exceptions;
using wakuwakuApi.Models;
using wakuwakuApi.Repositories.Interfaces;
using wakuwakuApi.Services.Interfaces;
using wakuwakuApi.Validators;

namespace wakuwakuApi.Services {
    public class CategoryService : ICategoryService {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;

        }

        public IEnumerable<Category> GetCategories(int page = 1, int pageSize = 10, string filter = "") {

            var categoryList = _categoryRepository.GetCategories();

            var paginatedCategories = categoryList.Skip((page - 1) * pageSize).Take(pageSize);

            if(!string.IsNullOrEmpty(filter)) {
                paginatedCategories =
                    paginatedCategories.Where(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)
                    || c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            return paginatedCategories;
        }

        public Category GetCategoryById(int categoryId) {
            var category = _categoryRepository.GetCategoryById(categoryId);

            return category;
        }

        public Category AddCategory(CategoryCreate categoryCreate) {
            var createdCategory = _categoryRepository.AddCategory(categoryCreate);

            return createdCategory;
        }

        public Category UpdateCategory(int categoryId, CategoryUpdate categoryUpdate) {
            Category UpdatedCategory = _categoryRepository.UpdateCategory(categoryId, categoryUpdate);

            return UpdatedCategory;
        }

        public Category DeleteCategoryById(int categoryId) {
            var category = _categoryRepository.DeleteCategoryById(categoryId);

            NotFoundException.ThrowIfNull(category);

            return category;
        }
    }
}