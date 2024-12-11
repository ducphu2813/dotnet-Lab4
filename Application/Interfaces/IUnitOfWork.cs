using Application.Interfaces.Repository;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    
    //khai báo các interface repository cần sử dụng
    ICartRepository CartRepository { get; }
    ICartDetailRepository CartDetailRepository { get; }
    IBookRepository BookRepository { get; }
    IGenreRepository GenreRepository { get; }
    
    //lưu thay đổi vào database
    Task<int> CompleteAsync();
}