using System;
using System.Collections.Generic;

namespace back.Models;

public partial class RoutineExercise
{
    public Guid Uuid { get; set; }

    public Guid? RoutineUuid { get; set; }

    public Guid? ExerciseUuid { get; set; }

    public int? ExerciseOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Exercise? ExerciseUu { get; set; }

    public virtual Routine? RoutineUu { get; set; }
}
