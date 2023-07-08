using System;
using System.Collections.Generic;

namespace api.Models;

public partial class GasStation
{
    public int? Id { get; set; }

    public int AddressId { get; set; }

    public int GasStation1Id { get; set; }

    public int GasStation2Id { get; set; }
}
