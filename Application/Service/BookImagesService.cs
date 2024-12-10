using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class BookImagesService : IBookImagesService
{
    protected readonly IBookImagesRepository _bookImagesRepository;
    
    public BookImagesService(IBookImagesRepository bookImagesRepository)
    {
        _bookImagesRepository = bookImagesRepository;
    }
    
    public async Task<List<BookImages>> GetAllAsync()
    {
        return (await _bookImagesRepository.GetAll()).ToList();   
    }

    public async Task<BookImages> GetByIdAsync(Guid id)
    {
        return await _bookImagesRepository.GetById(id);
    }

    public async Task<BookImages> AddAsync(BookImages bookImages)
    {
        return await _bookImagesRepository.Add(bookImages);
    }

    public async Task<BookImages> UpdateAsync(Guid id, BookImages bookImages)
    {
        return await _bookImagesRepository.Update(id, bookImages);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _bookImagesRepository.Remove(id);
    }
}