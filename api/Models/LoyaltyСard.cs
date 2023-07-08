using System;
using System.Collections.Generic;

namespace api.Models;

public partial class LoyaltyСard
{
    public int LoyaltyСard1 { get; set; }

    public string CardHolder { get; set; } = null!;

    public short Balance { get; set; }

    public int? Id { get; set; }
}
