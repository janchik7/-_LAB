using System;
using System.Collections.Generic;

namespace IKM1.Models;

public partial class Buyer
{
    public int BuyerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public decimal? Budget { get; set; }
}
