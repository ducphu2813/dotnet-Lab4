using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Service;

public interface IBookService
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(Guid id);
    Task<Book> AddAsync(SaveBook book);
    Task<Book> UpdateAsync(Guid id, SaveBook book);
    Task<bool> RemoveAsync(Guid id);
}