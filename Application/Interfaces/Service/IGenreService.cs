using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Service;

public interface IGenreService
{
    Task<List<Genre>> GetAllAsync();
    Task<Genre> GetByIdAsync(Guid id);
    Task<Genre> AddAsync(AddGenre genre);
    Task<Genre> UpdateAsync(Guid id, Genre genre);
    Task<bool> RemoveAsync(Guid id);
}