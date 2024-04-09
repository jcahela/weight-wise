using back.Models;
using Microsoft.EntityFrameworkCore;
using back.Dtos;

namespace back.Services;
public class UserService
{
  private readonly WeightwiseContext _DBContext;

  public UserService(WeightwiseContext dbContext)
  {
    _DBContext = dbContext;
  }

  public IList<UserDto> GetAllUsers()
  {
    return (
      _DBContext.Users
        .Select(u => u.ToDto())
        .ToList()
    );
  }
}
