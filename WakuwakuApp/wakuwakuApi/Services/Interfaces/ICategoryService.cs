using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wakuwakuApi.Models;

namespace wakuwakuApi.Services.Interfaces {
    public interface ICategoryService {
        IEnumerable<Category> GetCategories(int page, int pageSize, string filter);
    }
}
