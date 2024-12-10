using Domain.Entities;

namespace Application.Interfaces.Service;

public interface IBookImagesService
{
    Task<List<BookImages>> GetAllAsync();
    Task<BookImages> GetByIdAsync(Guid id);
    Task<BookImages> AddAsync(BookImages bookImages);
    Task<BookImages> UpdateAsync(Guid id, BookImages bookImages);
    Task<bool> RemoveAsync(Guid id);
}