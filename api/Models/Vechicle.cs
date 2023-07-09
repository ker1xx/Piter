using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Vechicle
{
    public int? Id { get; set; }

    public string CarNumber { get; set; } = null!;

    public string SupportedFuel { get; set; } = null!;

    public double SizeOfTank { get; set; }

    public double CurrentFuel { get; set; }
}
