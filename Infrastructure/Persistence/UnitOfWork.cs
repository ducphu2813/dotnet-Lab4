using Application.Interfaces;
using Application.Interfaces.Repository;
using Infrastructure.Context;
using Infrastructure.Repository;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly DatabaseContext _context;
    
    //những repository cần sử dụng
    public ICartRepository CartRepository { get; }
    public ICartDetailRepository CartDetailRepository { get; }
    public IBookRepository BookRepository { get; }
    public IGenreRepository GenreRepository { get; }
    
    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        CartRepository = new CartRepository(_context);
        CartDetailRepository = new CartDetailRepository(_context);
        BookRepository = new BookRepository(_context);
        GenreRepository = new GenreRepository(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}