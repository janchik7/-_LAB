using System;
using System.Collections.Generic;

namespace IKM1.Models;

public partial class Realtor
{
    public int RealtorId { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public decimal? CommissionRate { get; set; }

}
