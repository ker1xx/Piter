using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public string CardHolder { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public int? StationId { get; set; }

    public string FuelType { get; set; } = null!;

    public double Value { get; set; }

    public double Cost { get; set; }

    public string PaymentType { get; set; } = null!;

    public virtual Station? Station { get; set; }
}
