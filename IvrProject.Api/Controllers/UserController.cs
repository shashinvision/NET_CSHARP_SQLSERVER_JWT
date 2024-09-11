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
    private readonly ICommService<UserAddDto, UserDto, InsertedUserDto> _usersService;

    public UserController(ICommService<UserAddDto, UserDto, InsertedUserDto> usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("Users")]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _usersService.Get();
        return Ok(users);

    }
    [HttpGet("UserId/{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {

        var user = await _usersService.GetById(id);

        if (user == null)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }

    [HttpGet("UserName/{name}")]
    public async Task<ActionResult<UserDto>> GetUserByName(string name)
    {

        var user = await _usersService.GetByName(name);

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
            var user = await _usersService.Add(userAddDto);

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
            var user = await _usersService.Update(userAddDto);

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
            var user = await _usersService.Delete(id);

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
}
