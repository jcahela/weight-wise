using System.ComponentModel.DataAnnotations;

namespace back.Models;

public partial class RoutineExercise
{
    public Guid Uuid { get; set; }

    [Required]
    public Guid RoutineId { get; set; }

    [Required]
    public Guid ExerciseId { get; set; }

    [Required]
    public int ExerciseOrder { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Routine Routine { get; set; } = null!;
}
