using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Datum
{
    public int? Id { get; set; }

    public int StationId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int AmountOfFuel { get; set; }

}
