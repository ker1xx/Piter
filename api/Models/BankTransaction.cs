using System;
using System.Collections.Generic;

namespace api.Models;

public partial class BankTransaction
{
    public int? Id { get; set; }

    public int CardNubmer { get; set; }

    public string NameSurname { get; set; } = null!;

    public int AuthorizationCode { get; set; }

    public double Price { get; set; }

    public string OrgranizationName { get; set; } = null!;

    public int AzsId { get; set; }

    public string SessionKey { get; set; } = null!;
}
