using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Routine
{
    public Guid Uuid { get; set; }

    public Guid? UserUuid { get; set; }

    public int? IntervalInDays { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();

    public virtual User? UserUu { get; set; }

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
