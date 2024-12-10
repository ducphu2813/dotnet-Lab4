﻿using Application.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class BaseRepository <TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DatabaseContext _context;
    
    public BaseRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    //hàm lấy tất cả dữ liệu
    public async virtual Task<IEnumerable<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async virtual Task<TEntity> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async virtual Task<TEntity> Add(TEntity obj)
    {
        await _context.Set<TEntity>().AddAsync(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public async virtual Task<TEntity> Update(Guid id, TEntity obj)
    {
        _context.Set<TEntity>().Update(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public async virtual Task<bool> Remove(Guid id)
    {
        
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async virtual Task<List<TEntity>> GetAllByIds(List<Guid> ids)
    {
        return await _context.Set<TEntity>()
            .Where(x => ids.Contains((Guid)x.GetType().GetProperty("Id")
                .GetValue(x, null)))
            .ToListAsync<TEntity>();
    }
}