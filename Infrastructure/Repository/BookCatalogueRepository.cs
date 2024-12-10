using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class BookCatalogueRepository : BaseRepository<BookCatalogue>, IBookCatalogueRepository
{
    public BookCatalogueRepository(DatabaseContext context) : base(context)
    {
        
    }
    
}