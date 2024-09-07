using System;
using Microsoft.AspNetCore.Mvc;
using IvrProject.Api.Model;

namespace IvrProject.Api.Interfaces;

public interface ICommService<TEntity, TEntityDto, TInsertDto>
{
    public Task<List<TEntityDto>> Get();
    public Task<TEntityDto> GetById(int id);
    public Task<TEntityDto> GetByName(TEntityDto entity);
    public Task<TInsertDto> Add(TEntity entity);
    public Task<TEntityDto> Update(TEntity entity);
    public Task<TEntityDto> Delete(int id);
}