using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(DatabaseContext context) : base(context)
    {
    }
    
}