using back.Dtos;

namespace back.Models;

public static class UserExtensions
{
  public static UserDto ToDto(this User user)
  {
    return new UserDto
    (
      Uuid: user.Uuid,
      Username: user.Username,
      Email: user.Email,
      Routines: user.Routines,
      CreatedAt: user.CreatedAt,
      UpdatedAt: user.UpdatedAt,
      DeletedAt: user.DeletedAt
    );
  }
}
