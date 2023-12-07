using wakuwakuApi.Models;

namespace wakuwakuApi.Persistence.Interfaces;

public interface IInMemoryPersistenceService {
    IList<Category> Categories { get; set; }
}
