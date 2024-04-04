using System.ComponentModel.DataAnnotations;

namespace back.Models;

public partial class RoutineExercise
{
    public Guid Uuid { get; set; }

    [Required]
    public Guid RoutineUuid { get; set; }

    [Required]
    public Guid ExerciseUuid { get; set; }

    [Required]
    public int ExerciseOrder { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Exercise ExerciseUu { get; set; } = null!;

    public virtual Routine RoutineUu { get; set; } = null!;
}
