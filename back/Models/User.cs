using System.ComponentModel.DataAnnotations;

namespace back.Models;

public partial class User
{
    public Guid Uuid { get; set; }

    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
