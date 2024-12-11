using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using Domain.Exception;

namespace Application.Service;

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CartService(IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<List<Cart>> GetAllAsync()
    {
        return (List<Cart>) await _unitOfWork.CartRepository.GetAll();
    }

    public async Task<CartResponse> GetByIdAsync(Guid id)
    {
        
        Cart cart = await _unitOfWork.CartRepository.GetById(id);
        
        if (cart == null)
        {
            throw new NotFoundException("Cart not found");
        }
        
        return _mapper.Map<CartResponse>(cart);
    }

    public async Task<Cart> AddAsync(SaveCart cart)
    {
        Cart newCart = new()
        {
            Code = cart.Code,
            Note = cart.Note,
            Status = cart.Status,
            IsActive = cart.IsActive,
            CreatedOn = cart.CreatedOn
        };
        
        Cart addedCart = await _unitOfWork.CartRepository.Add(newCart);

        await _unitOfWork.CompleteAsync();
        
        return addedCart;
    }

    public async Task<Cart> UpdateAsync(Guid id, SaveCart cart)
    {
        //tìm cart theo id
        var cartById = await _unitOfWork.CartRepository.GetById(id);
        
        //nếu không tìm thấy cart
        if (cartById == null)
        {
            throw new NotFoundException("Cart not found");
        }
        
        Cart newCart = new()
        {
            Id = id,
            Code = cart.Code,
            Note = cart.Note,
            Status = cart.Status,
            IsActive = cart.IsActive,
            CreatedOn = cart.CreatedOn
        };
        
        Cart updatedCart = await _unitOfWork.CartRepository.Update(id, newCart);
        
        await _unitOfWork.CompleteAsync();
        
        return updatedCart;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        //tìm cart theo id
        var cartById = await _unitOfWork.CartRepository.GetById(id);
        
        //nếu không tìm thấy cart
        if (cartById == null)
        {
            throw new NotFoundException("Cart not found");
        }
        
        await _unitOfWork.CartRepository.Remove(id);
        
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
}