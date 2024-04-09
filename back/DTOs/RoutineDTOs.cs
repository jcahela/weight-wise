using System.ComponentModel.DataAnnotations;
using back.Models;

namespace back.Dtos;

public record RoutineDto(
  [Required] string Name,
  [Required] int IntervalInDays,
  [Required] DateTime CreatedAt,
  [Required] DateTime UpdatedAt,
  [Required] ICollection<ExerciseDto> Exercises,
  DateTime? DeletedAt
);
