using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    
    public GenreRepository(DatabaseContext context) : base(context)
    {
    }
    
}