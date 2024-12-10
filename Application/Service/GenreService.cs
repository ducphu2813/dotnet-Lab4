using Application.DTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class GenreService : IGenreService
{
    protected readonly IGenreRepository _genreRepository;
    
    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    
    public async Task<List<Genre>> GetAllAsync()
    {
        return (await _genreRepository.GetAll()).ToList();
    }

    public async Task<Genre> GetByIdAsync(Guid id)
    {
        return await _genreRepository.GetById(id);
    }

    public async Task<Genre> AddAsync(AddGenre genre)
    {
        Genre newGenre = new Genre
        {
            Name = genre.Name,
            IsActive = genre.IsActive
        };
        
        return await _genreRepository.Add(newGenre);
    }

    public async Task<Genre> UpdateAsync(Guid id, Genre genre)
    {
        return await _genreRepository.Update(id, genre);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _genreRepository.Remove(id);
    }
}