using Domain.Entities;

namespace Application.Interfaces.Service;

public interface IBookCatalogueService
{
    //các hàm CRUD cơ bản
    Task<List<BookCatalogue>> GetAllAsync();
    Task<BookCatalogue> GetByIdAsync(Guid id);
    Task<BookCatalogue> AddAsync(BookCatalogue bookCatalogue);
    Task<BookCatalogue> UpdateAsync(Guid id, BookCatalogue bookCatalogue);
    Task<bool> RemoveAsync(Guid id);
}