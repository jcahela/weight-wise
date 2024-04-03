using System;
using System.Collections.Generic;

namespace back.Models;

public partial class User
{
    public Guid Uuid { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
