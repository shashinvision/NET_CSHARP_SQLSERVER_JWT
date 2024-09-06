using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SQL_SERVER_API.DTOs;
using SQL_SERVER_API.Model.Entities;
using SQL_SERVER_API.Interfaces;


namespace SQL_SERVER_API.Controllers;

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
    public async Task<ActionResult<List<UserDto>>> GetUser(int id)
    {

        var user = await _usersService.GetById(id);

        if (user.Count < 1)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }

    [Authorize(Roles = "2")]
    [HttpPost("User")]
    public async Task<ActionResult<List<InsertedUserDto>>> AddUser([FromBody] User newUser)
    {

        try
        {
            var user = await _usersService.Add(newUser);

            if (user.Count < 1)
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
    public async Task<ActionResult<List<UserDto>>> UpdateUser([FromBody] User updateUser)
    {

        try
        {
            var user = await _usersService.Update(updateUser);

            if (user.Count < 1)
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
    public async Task<ActionResult<List<UserDto>>> DeleteUser(int id)
    {

        var user = await _usersService.Delete(id);

        if (user.Count < 1)
        {
            return BadRequest("User Not found");
        }

        return Ok(user);

    }
}
