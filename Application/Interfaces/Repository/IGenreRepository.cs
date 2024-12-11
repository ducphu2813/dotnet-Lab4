using Domain.Entities;

namespace Application.Interfaces.Repository;

public interface IGenreRepository : IRepository<Genre>
{
    //kiểm tra id genre có tồn tại ko
    Task<bool> IsGenreExist(Guid genreId);
}