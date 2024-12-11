using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using Domain.Exception;

namespace Application.Service;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public BookService(IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<List<Book>> GetAllAsync()
    {
        return (await _unitOfWork.BookRepository.GetAll()).ToList();
    }
    
    

    public async Task<Book> GetByIdAsync(Guid id)
    {
        return await _unitOfWork.BookRepository.GetById(id);
    }

    public async Task<Book> AddAsync(SaveBook book)
    {
        //kiểm tra id genre có tồn tại ko
        if (!await _unitOfWork.GenreRepository.IsGenreExist(book.GenreId))
        {
            throw new NotFoundException("Genre not found");
        }
        
        // var bookEntity = new Book
        // {
        //     Code = book.Code,
        //     Title = book.Title,
        //     Author = book.Author,
        //     Description = book.Description,
        //     Cost = book.Cost,
        //     CreateOn = DateTime.Now,
        //     IsActive = book.IsActive,
        //     Available = book.Available,
        //     Publisher = book.Publisher,
        //     GenreId = book.GenreId
        // };
        
        //dùng automapper
        var bookEntity = _mapper.Map<Book>(book);
        
        Book addedBook = await _unitOfWork.BookRepository.Add(bookEntity);

        await _unitOfWork.CompleteAsync();
        
        return addedBook;
    }

    public async Task<Book> UpdateAsync(Guid id, SaveBook book)
    {
        //tìm xem book id có tồn tại ko
        var bookEntity = await _unitOfWork.BookRepository.GetById(id);
        
        if (bookEntity == null)
        {
            throw new NotFoundException("Book not found");
        }
        
        //kiểm tra id genre có tồn tại ko
        if (!await _unitOfWork.GenreRepository.IsGenreExist(book.GenreId))
        {
            throw new NotFoundException("Genre not found");
        }
        
        //dùng automapper
        _mapper.Map(book, bookEntity);
        
        await _unitOfWork.BookRepository.Update(id, bookEntity);
        
        await _unitOfWork.CompleteAsync();
        
        return bookEntity;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _unitOfWork.BookRepository.Remove(id);
    }
}