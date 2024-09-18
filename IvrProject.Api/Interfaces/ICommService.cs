namespace IvrProject.Api.Interfaces;

public interface ICommService<TEntity, TEntityDto, TInsertDto>
{
    public Task<List<TEntityDto>> Get();
    public Task<TEntityDto> GetById(int id);
    public Task<TEntityDto> GetByName(string userName);
    public Task<TInsertDto> Add(TEntity entity);
    public Task<TEntityDto> Update(TEntity entity);
    public Task<TEntityDto> Deactivate(int id);

}
