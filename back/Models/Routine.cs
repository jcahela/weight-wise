using System.ComponentModel.DataAnnotations;

namespace back.Models;

public partial class Routine
{
    public Guid Uuid { get; set; }

    [Required]
    public Guid UserUuid { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int IntervalInDays { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();

    public virtual User UserUu { get; set; } = null!;

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
