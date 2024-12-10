using Domain.Entities;

namespace Application.Interfaces.Service;

public interface IBookService
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(Guid id);
    Task<Book> AddAsync(Book book);
    Task<Book> UpdateAsync(Guid id, Book book);
    Task<bool> RemoveAsync(Guid id);
}