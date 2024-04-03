using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Exercise
{
    public Guid Uuid { get; set; }

    public string? Name { get; set; }

    public string? Instructions { get; set; }

    public string? ImagePath0 { get; set; }

    public string? ImagePath1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();

    public virtual ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}
