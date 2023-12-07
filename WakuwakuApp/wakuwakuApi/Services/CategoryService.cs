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

            var categoryList = _categoryRepository.GetCategories(page, pageSize, filter);

            var paginatedCategories = categoryList.Skip((page - 1) * pageSize).Take(pageSize);

            if(!string.IsNullOrEmpty(filter)) {
                paginatedCategories =
                    paginatedCategories.Where(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)
                    || c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            return paginatedCategories;
        }

    }
}
