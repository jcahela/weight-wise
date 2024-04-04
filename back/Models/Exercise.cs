using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Exercise
{
    public Guid Uuid { get; set; }

    public string? Name { get; set; }

    public string? Force { get; set; }

    public string? Level { get; set; }

    public string? Mechanic { get; set; }

    public string? Equipment { get; set; }

    public IList<string>? PrimaryMuscles { get; set; }

    public IList<string>? SecondaryMuscles { get; set; }

    public string? Instructions { get; set; }

    public string? Category { get; set; }

    public string? ImagePath0 { get; set; }

    public string? ImagePath1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();

    public virtual ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}
