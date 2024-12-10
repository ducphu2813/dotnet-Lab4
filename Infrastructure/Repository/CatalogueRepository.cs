using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class CatalogueRepository : BaseRepository<Catalogue>, ICatalogueRepository
{
    
    public CatalogueRepository(DatabaseContext context) : base(context)
    {
    }
    
}