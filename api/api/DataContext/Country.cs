using System;
using System.Collections.Generic;

namespace api.DataContext;

public partial class Country
{
    public int Id { get; set; }

    public Guid CountryExternalId { get; set; }

    public string CountryName { get; set; } = null!;
}
