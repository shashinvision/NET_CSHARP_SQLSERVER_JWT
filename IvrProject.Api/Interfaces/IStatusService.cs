using System;

namespace IvrProject.Api.Interfaces;

public interface IStatusService<TEntityDto>
{
    public Task<TEntityDto> Activate(int id);
}
