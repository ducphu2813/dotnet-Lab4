using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class BookCatalogueService : IBookCatalogueService
{
    protected readonly IBookCatalogueRepository _bookCatalogueRepository;
    
    public BookCatalogueService(IBookCatalogueRepository bookCatalogueRepository)
    {
        _bookCatalogueRepository = bookCatalogueRepository;
    }
    
    public async Task<List<BookCatalogue>> GetAllAsync()
    {
        return (await _bookCatalogueRepository.GetAll()).ToList();
    }

    public async Task<BookCatalogue> GetByIdAsync(Guid id)
    {
        return await _bookCatalogueRepository.GetById(id);
    }

    public async Task<BookCatalogue> AddAsync(BookCatalogue bookCatalogue)
    {
        return await _bookCatalogueRepository.Add(bookCatalogue);
    }

    public async Task<BookCatalogue> UpdateAsync(Guid id, BookCatalogue bookCatalogue)
    {
        return await _bookCatalogueRepository.Update(id, bookCatalogue);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _bookCatalogueRepository.Remove(id);
    }
}