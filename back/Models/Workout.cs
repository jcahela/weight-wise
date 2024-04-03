using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Workout
{
    public Guid Uuid { get; set; }

    public Guid? RoutineUuid { get; set; }

    public DateTime? ScheduledAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Routine? RoutineUu { get; set; }

    public virtual ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}
