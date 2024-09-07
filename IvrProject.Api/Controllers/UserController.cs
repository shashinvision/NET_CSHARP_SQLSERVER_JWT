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
    private readonly ICommService<User, UserDto, InsertedUserDto> _usersService;

    public UserController(ICommService<User, UserDto, InsertedUserDto> usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("User")]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _usersService.Get();
        return Ok(users);

    }
    [HttpGet("User/{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {

        var user = await _usersService.GetById(id);

        if (user == null)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }

    [Authorize(Roles = "2")]
    [HttpPost("User")]
    public async Task<ActionResult<InsertedUserDto>> AddUser([FromBody] User newUser)
    {

        try
        {
            var user = await _usersService.Add(newUser);

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
    public async Task<ActionResult<UserDto>> UpdateUser([FromBody] User updateUser)
    {

        try
        {
            var user = await _usersService.Update(updateUser);

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

        var user = await _usersService.Delete(id);

        if (user == null)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }
}
