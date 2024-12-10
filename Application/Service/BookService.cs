using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class BookService : IBookService
{
    protected readonly IBookRepository _bookRepository;
    
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<List<Book>> GetAllAsync()
    {
        return (await _bookRepository.GetAll()).ToList();
    }

    public async Task<Book> GetByIdAsync(Guid id)
    {
        return await _bookRepository.GetById(id);
    }

    public async Task<Book> AddAsync(Book book)
    {
        return await _bookRepository.Add(book);
    }

    public async Task<Book> UpdateAsync(Guid id, Book book)
    {
        return await _bookRepository.Update(id, book);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _bookRepository.Remove(id);
    }
}