using wakuwakuApi.Models;

namespace wakuwakuApi.Repositories.Interfaces {
    public interface ICategoryRepository {

        IEnumerable<Category> GetCategories(int page, int pageSize, string filter);

    }
}
