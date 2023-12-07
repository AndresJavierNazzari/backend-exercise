using Microsoft.AspNetCore.Mvc.RazorPages;
using wakuwakuApi.Models;
using wakuwakuApi.Repositories.Interfaces;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Services {
    public class CategoryService : ICategoryService {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories(int page, int pageSize, string filter) {
            var result = _categoryRepository.GetCategories(page, pageSize, filter);
            return result;
        }

    }
}
