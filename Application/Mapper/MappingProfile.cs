using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cart, CartResponse>();
        CreateMap<CartDetail, CartDetailResponse>();
        CreateMap<Book, BookResponse>();
        CreateMap<Genre, GenreResponse>();
        CreateMap<Book, SaveBook>();
        CreateMap<SaveBook, Book>();
    }
    
}