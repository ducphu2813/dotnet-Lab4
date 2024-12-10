using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class CatalogueService : ICatalogueService
{
    protected readonly ICatalogueRepository _catalogueRepository;
    
    public CatalogueService(ICatalogueRepository catalogueRepository)
    {
        _catalogueRepository = catalogueRepository;
    }
    
    public async Task<List<Catalogue>> GetAllAsync()
    {
        return (await _catalogueRepository.GetAll()).ToList();
    }

    public async Task<Catalogue> GetByIdAsync(Guid id)
    {
        return await _catalogueRepository.GetById(id);
    }

    public async Task<Catalogue> AddAsync(Catalogue catalogue)
    {
        return await _catalogueRepository.Add(catalogue);
    }

    public async Task<Catalogue> UpdateAsync(Guid id, Catalogue catalogue)
    {
        return await _catalogueRepository.Update(id, catalogue);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _catalogueRepository.Remove(id);
    }
}