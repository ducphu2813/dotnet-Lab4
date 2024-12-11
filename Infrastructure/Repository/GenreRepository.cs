using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    
    public GenreRepository(DatabaseContext context) : base(context)
    {
    }
    
    public async Task<bool> IsGenreExist(Guid genreId)
    {
        return await _context.Genres.AnyAsync(x => x.Id == genreId);
    }
    
}