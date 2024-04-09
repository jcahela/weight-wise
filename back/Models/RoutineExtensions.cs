using back.Dtos;

namespace back.Models;

public static class RoutineExtensions
{
  public static RoutineDto ToDto(this Routine routine)
  {
    return new RoutineDto
    (
      Name: routine.Name,
      IntervalInDays: routine.IntervalInDays,
      CreatedAt: routine.CreatedAt,
      UpdatedAt: routine.UpdatedAt,
      DeletedAt: routine.DeletedAt
    );
  }
}
