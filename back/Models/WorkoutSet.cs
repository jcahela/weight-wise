using System.ComponentModel.DataAnnotations;

namespace back.Models;

public partial class WorkoutSet
{
    public Guid Uuid { get; set; }

    [Required]
    public Guid WorkoutUuid { get; set; }

    public Guid ExerciseUuid { get; set; }

    [Required]
    public int SetOrder { get; set; }

    [Required]
    public int Reps { get; set; }

    [Required]
    public decimal Weight { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Exercise ExerciseUu { get; set; } = null!;

    public virtual Workout WorkoutUu { get; set; } = null!;
}
