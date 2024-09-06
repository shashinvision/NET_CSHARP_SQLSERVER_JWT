using System;
using Microsoft.AspNetCore.Mvc;
using SQL_SERVER_API.Model;

namespace SQL_SERVER_API.Interfaces;

public interface ICommService<TEntity, TEntityDto, TInsertDto>
{
    public Task<List<TEntityDto>> Get();
    public Task<List<TEntityDto>> GetById(int id);
    public Task<List<TEntityDto>> GetByName(TEntityDto entity);
    public Task<List<TInsertDto>> Add(TEntity entity);
    public Task<List<TEntityDto>> Update(TEntity entity);
    public Task<List<TEntityDto>> Delete(int id);
}
