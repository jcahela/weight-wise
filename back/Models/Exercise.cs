using System.ComponentModel.DataAnnotations;

namespace back.Models;

public class AtLeastOneElementAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is IList<string> list)
        {
            return list.Count > 0;
        }
        return false;
    }
}

public class Exercise
{
    public Guid Uuid { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Exercise name must be less than 100 characters")]
    public string Name { get; set; } = null!;

    public string? Force { get; set; }

    [Required]
    public string Level { get; set; } = null!;

    public string? Mechanic { get; set; }

    public string? Equipment { get; set; }

    [Required]
    [AtLeastOneElement(ErrorMessage = "Exercise must have at least one primary muscle")]
    public IList<string> PrimaryMuscles { get; set; } = new List<string>();

    public IList<string>? SecondaryMuscles { get; set; }

    public string? Instructions { get; set; }

    [Required]
    public string Category { get; set; } = null!;

    public string? ImagePath0 { get; set; }

    public string? ImagePath1 { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();

    public virtual ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}
