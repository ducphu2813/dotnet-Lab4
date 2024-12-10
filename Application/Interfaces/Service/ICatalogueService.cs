using Domain.Entities;

namespace Application.Interfaces.Service;

public interface ICatalogueService
{
    Task<List<Catalogue>> GetAllAsync();
    Task<Catalogue> GetByIdAsync(Guid id);
    Task<Catalogue> AddAsync(Catalogue catalogue);
    Task<Catalogue> UpdateAsync(Guid id, Catalogue catalogue);
    Task<bool> RemoveAsync(Guid id);
}