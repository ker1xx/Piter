using System;
using System.Collections.Generic;

namespace api.Models;

public partial class CameraLoad
{
    public DateTime Date { get; set; }

    public bool Status { get; set; }

    public string? StateNumber { get; set; }

    public string Img { get; set; } = null!;

    public int? Id { get; set; }
}
