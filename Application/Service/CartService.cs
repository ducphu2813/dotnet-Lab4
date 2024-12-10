using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;

namespace Application.Service;

public class CartService : ICartService
{
    protected readonly ICartRepository _cartRepository;
    
    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    
    public async Task<List<Cart>> GetAllAsync()
    {
        return (await _cartRepository.GetAll()).ToList();
    }

    public async Task<Cart> GetByIdAsync(Guid id)
    {
        return await _cartRepository.GetById(id);
    }

    public async Task<Cart> AddAsync(Cart cart)
    {
        return await _cartRepository.Add(cart);
    }

    public async Task<Cart> UpdateAsync(Guid id, Cart cart)
    {
        return await _cartRepository.Update(id, cart);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _cartRepository.Remove(id);
    }
}