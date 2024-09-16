using System;
using IvrProject.Api.Model.DTOs;

namespace IvrProject.Api.Interfaces;

public interface IRolesService
{
    public Task<List<RolesDto>> GetRoles();
}
