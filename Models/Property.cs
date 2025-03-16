using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKM1.Models;

public partial class Property
{
    public int PropertyId { get; set; }

    public string Address { get; set; } = null!;

    public decimal Price { get; set; }

    public string PropertyType { get; set; } = null!;

    public int? RealtorId { get; set; }

    public int? ClientId { get; set; }

}
