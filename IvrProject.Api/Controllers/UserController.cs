using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Interfaces;


namespace IvrProject.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ICommService<UserAddDto, UserDto, InsertedUserDto> _userCommService;
    private readonly IRolesService _userRolesService;

    public UserController(ICommService<UserAddDto, UserDto, InsertedUserDto> userCommService, IRolesService userRolesService)
    {
        _userCommService = userCommService;
        _userRolesService = userRolesService;
    }

    [HttpGet("Users")]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _userCommService.Get();
        return Ok(users);

    }
    [HttpGet("UserId/{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {

        var user = await _userCommService.GetById(id);

        if (user == null)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }

    [HttpGet("UserName/{name}")]
    public async Task<ActionResult<UserDto>> GetUserByName(string name)
    {

        var user = await _userCommService.GetByName(name);

        if (user == null)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }

    [Authorize(Roles = "admin, moderator")]
    [HttpPost("User")]
    public async Task<ActionResult<InsertedUserDto>> AddUser([FromBody] UserAddDto userAddDto)
    {

        try
        {
            var user = await _userCommService.Add(userAddDto);

            if (user == null)
            {
                return BadRequest("User already exists");
            }

            return Ok(user);
        }
        catch (System.Exception)
        {

            return BadRequest("Error try insert user");
        }

    }
    [HttpPut("User")]
    public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserAddDto userAddDto)
    {

        try
        {
            var user = await _userCommService.Update(userAddDto);

            if (user == null)
            {
                return BadRequest("User Not found");
            }

            return Ok(user);
        }
        catch (System.Exception)
        {

            return BadRequest("Error try update user");
        }

    }
    [HttpDelete("User/{id}")]
    public async Task<ActionResult<UserDto>> DeleteUser(int id)
    {

        try
        {
            var user = await _userCommService.Delete(id);

            if (user == null)
            {
                return BadRequest("User Not found");
            }

            return Ok(user);

        }
        catch (System.Exception)
        {

            return BadRequest("Error try delete user");
        }

    }
    [HttpGet("Roles")]
    public async Task<ActionResult<List<RolesDto>>> GetRoles(){

        var roles = await _userRolesService.GetRoles();
        return Ok(roles);
    }
}
