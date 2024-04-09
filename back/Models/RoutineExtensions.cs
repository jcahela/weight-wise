using back.Dtos;

namespace back.Models;

public static class RoutineExtensions
{
  public static RoutineDto ToDto(this Routine routine)
  {
    var exercises = routine.Exercises.Select(e => e.ToDto()).ToList();

    return new RoutineDto
    (
      Name: routine.Name,
      IntervalInDays: routine.IntervalInDays,
      CreatedAt: routine.CreatedAt,
      UpdatedAt: routine.UpdatedAt,
      Exercises: exercises,
      DeletedAt: routine.DeletedAt
    );
  }
}
