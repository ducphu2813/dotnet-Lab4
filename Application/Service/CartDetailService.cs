using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class CartDetailService : ICartDetailService
{
    protected readonly ICartDetailRepository _cartDetailRepository;
    
    public CartDetailService(ICartDetailRepository cartDetailRepository)
    {
        _cartDetailRepository = cartDetailRepository;
    }
    
    public async Task<List<CartDetail>> GetAllAsync()
    {
        return (await _cartDetailRepository.GetAll()).ToList();
    }

    public async Task<CartDetail> GetByIdAsync(Guid id)
    {
        return await _cartDetailRepository.GetById(id);
    }

    public async Task<CartDetail> AddAsync(CartDetail cartDetail)
    {
        return await _cartDetailRepository.Add(cartDetail);
    }

    public async Task<CartDetail> UpdateAsync(Guid id, CartDetail cartDetail)
    {
        return await _cartDetailRepository.Update(id, cartDetail);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _cartDetailRepository.Remove(id);
    }
}