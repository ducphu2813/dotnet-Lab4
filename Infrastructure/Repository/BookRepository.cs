using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) : base(context)
    {
    }
    
    //hàm kiểm tra id book có tồn tại ko
    public async Task<bool> IsBookExist(Guid id)
    {
        return await _context.Books.AnyAsync(x => x.Id == id);
    }
    
}