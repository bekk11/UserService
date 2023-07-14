using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewUserService.Data;
using NewUserService.Models;
using NewUserService.Models.Templates;
using NewUserService.Response;

namespace NewUserService.Controllers;

[Route("users")]
[ApiController]
public class UserController : Controller
{
    private readonly AppDbContext _appDbContext;

    public UserController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListUserAsync()
    {
        List<User> users = await _appDbContext.Users.ToListAsync();

        return Ok(new BaseResponse<List<User>>
            { Success = true, Message = "SUCCESS", Data = users }
        );
    }

    [HttpGet]
    [Route("get/{pk}")]
    public async Task<IActionResult> GetUserByIdAsync(long pk)
    {
        User? user = await _appDbContext.Users.FindAsync(pk);

        if (user == null)
            return NotFound(new BaseResponse<User>
                { Success = false, Message = "USER WITH THIS ID DOES NOT EXISTS", Data = null });

        return Ok(new BaseResponse<User>
            { Success = true, Message = "SUCCESS", Data = user });
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateNewUser(UserCreateTemplate userCreateTemplate)
    {
        User user = new User();
        user.CreateUser(userCreateTemplate);

        _appDbContext.Users.Add(user);

        await _appDbContext.SaveChangesAsync();

        return Created("", new BaseResponse<User> { Success = true, Message = "SUCCESSFULLY CREATED", Data = user });
    }

    [HttpPut]
    [Route("update/{pk}")]
    public async Task<IActionResult> UpdateUserByIdAsync(long pk, UserCreateTemplate userCreateTemplate)
    {
        User? user = await _appDbContext.Users.FindAsync(pk);

        if (user == null)
        {
            return NotFound(new BaseResponse<User>
                { Success = false, Message = "USER WITH THIS ID DOES NOT EXISTS", Data = null });
        }
        
        user.UpdateUser(userCreateTemplate);

        await _appDbContext.SaveChangesAsync();

        return Ok(new BaseResponse<User> { Success = true, Message = "SUCCESSFULLY UPDATED", Data = user });
    }

    [HttpDelete]
    [Route("delete/{pk}")]
    public async Task<IActionResult> DeleteUserById(long pk)
    {
        User? user = await _appDbContext.Users.FindAsync(pk);

        if (user == null)
        {
            return NotFound(new BaseResponse<User>
                { Success = false, Message = "USER WITH THIS ID DOES NOT EXISTS", Data = null });
        }
        
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }
}