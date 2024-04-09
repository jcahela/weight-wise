using back.Dtos;

namespace back.Models;

public static class UserExtensions
{
  public static UserDto ToDto(this User user)
  {
    var routineDtos = user.Routines.Select(r => r.ToDto()).ToList();

    return new UserDto
    (
      Uuid: user.Uuid,
      Username: user.Username,
      Email: user.Email,
      Routines: routineDtos,
      CreatedAt: user.CreatedAt,
      UpdatedAt: user.UpdatedAt,
      DeletedAt: user.DeletedAt
    );
  }
}
