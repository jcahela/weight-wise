using System.ComponentModel.DataAnnotations;
using back.Models;

namespace back.Dtos;

public record ExerciseDto(
  Guid Uuid,
  [Required] [StringLength(100, ErrorMessage = "Exercise name must be less than 100 characters")] string Name,
  string? Force,
  [Required] string Level,
  string? Mechanic,
  string? Equipment,
  [Required] [AtLeastOneElement(ErrorMessage = "Exercise must have at least one primary muscle")] IList<string> PrimaryMuscles,
  IList<string?> SecondaryMuscles,
  string? Instructions,
  [Required] string Category,
  string? ImagePath0,
  string? ImagePath1,
  [Required] DateTime CreatedAt
);
