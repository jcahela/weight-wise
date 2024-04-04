using System.ComponentModel.DataAnnotations;

namespace back.Models;

public partial class Workout
{
    public Guid Uuid { get; set; }

    [Required]
    public Guid RoutineUuid { get; set; }

    [Required]
    public DateTime ScheduledAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Routine RoutineUu { get; set; } = null!;

    public virtual ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}
