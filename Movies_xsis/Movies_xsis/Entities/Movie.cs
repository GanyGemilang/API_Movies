using System;
using System.Collections.Generic;

namespace Movies_xsis.Entities;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public float? Rating { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
