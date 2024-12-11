using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;
using Domain.Exception;

namespace Application.Service;

public class CartDetailService : ICartDetailService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CartDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CartDetail>> GetAllAsync()
    {
        List<CartDetail> result = (await _unitOfWork.CartDetailRepository.GetAll()).ToList();
        
        return result;
    }

    public async Task<CartDetail> GetByIdAsync(Guid id)
    {
        return await _unitOfWork.CartDetailRepository.GetById(id);
    }

    public async Task<CartDetail> AddAsync(CartDetail cartDetail)
    {
        CartDetail cart = await _unitOfWork.CartDetailRepository.Add(cartDetail);

        await _unitOfWork.CompleteAsync();
        
        return cart;
    }

    public async Task<CartDetail> UpdateAsync(Guid id, CartDetail cartDetail)
    {
        CartDetail cart = await _unitOfWork.CartDetailRepository.Update(id, cartDetail);

        await _unitOfWork.CompleteAsync();
        
        return cart;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        CartDetail cart = await _unitOfWork.CartDetailRepository.GetById(id);
        
        if (cart == null)
        {
            throw new NotFoundException("Cart detail not found");
        }
        
        await _unitOfWork.CartDetailRepository.Remove(id);

        await _unitOfWork.CompleteAsync();
        
        return true;
    }
    
    //thêm sách vào cart
    public async Task AddBookToCart(SaveCartDetail cartDetail)
    {
        
        await _unitOfWork.CartDetailRepository.AddBookToCart(cartDetail.CartId, cartDetail.BookId);
        
        await _unitOfWork.CompleteAsync();
    }
    
    //chỉnh sửa số lượng sách trong cart
    public async Task UpdateQuantity(SaveCartDetail cartDetail, int quantity)
    {
        
        await _unitOfWork.CartDetailRepository.UpdateQuantity(cartDetail.CartId, cartDetail.BookId, quantity);
        
        await _unitOfWork.CompleteAsync();
    }
    
    //xóa sách khỏi cart
    public async Task RemoveBookFromCart(SaveCartDetail cartDetail)
    {
        await _unitOfWork.CartDetailRepository.RemoveBookFromCart(cartDetail.CartId, cartDetail.BookId);
        
        await _unitOfWork.CompleteAsync();
    }
    
    //xóa cart detail theo id cart
    public async Task RemoveCartDetailByCartId(Guid cartId)
    {
        await _unitOfWork.CartDetailRepository.RemoveCartDetailByCartId(cartId);
        
        await _unitOfWork.CompleteAsync();
    }
}