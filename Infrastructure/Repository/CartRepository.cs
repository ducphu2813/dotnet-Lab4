using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(DatabaseContext context) : base(context)
    {
    }
    
    //ghi đè lên hàm get by id
    public async override Task<Cart> GetById(Guid id)
    {
        return await _context.Carts
            .Include(c => c.CartDetails)
                .ThenInclude(cd => cd.Book)
                    .ThenInclude(b => b.Genre)
            .FirstOrDefaultAsync(c => c.Id == id);

    }
    
}