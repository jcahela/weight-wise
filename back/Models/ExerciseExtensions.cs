using back.Dtos;

namespace back.Models;

public static class ExerciseExtensions
{
  public static ExerciseDto ToDto(this Exercise exercise)
  {
    return new ExerciseDto
    (
      Uuid: exercise.Uuid,
      Name: exercise.Name,
      Force: exercise.Force,
      Level: exercise.Level,
      Mechanic: exercise.Mechanic,
      Equipment: exercise.Equipment,
      PrimaryMuscles: exercise.PrimaryMuscles,
      SecondaryMuscles: exercise.SecondaryMuscles?.Select(s => (string?)s).ToList() ?? new List<string?>(),
      Instructions: exercise.Instructions,
      Category: exercise.Category,
      ImagePath0: exercise.ImagePath0,
      ImagePath1: exercise.ImagePath1,
      CreatedAt: exercise.CreatedAt
    );
  }
}
