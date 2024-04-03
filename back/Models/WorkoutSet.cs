using System;
using System.Collections.Generic;

namespace back.Models;

public partial class WorkoutSet
{
    public Guid Uuid { get; set; }

    public Guid? WorkoutUuid { get; set; }

    public Guid? ExerciseUuid { get; set; }

    public int? SetOrder { get; set; }

    public int? Reps { get; set; }

    public decimal? Weight { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Exercise? ExerciseUu { get; set; }

    public virtual Workout? WorkoutUu { get; set; }
}
