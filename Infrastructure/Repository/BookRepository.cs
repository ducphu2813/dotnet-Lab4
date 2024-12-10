using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) : base(context)
    {
    }
    
}