using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repository;

public class CartDetailRepository : BaseRepository<CartDetail>, ICartDetailRepository
{
    public CartDetailRepository(DatabaseContext context) : base(context)
    {
    }
    
}