using Domain.Entities;

namespace Application.Interfaces.Repository;

public interface IBookRepository : IRepository<Book>
{
    //hàm kiểm tra id book có tồn tại ko
    Task<bool> IsBookExist(Guid id);
}