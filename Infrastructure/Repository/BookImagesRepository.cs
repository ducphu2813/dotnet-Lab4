using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class BookImagesRepository : BaseRepository<BookImages>, IBookImagesRepository
{
    
    public BookImagesRepository(DatabaseContext context) : base(context)
    {
        
    }
}