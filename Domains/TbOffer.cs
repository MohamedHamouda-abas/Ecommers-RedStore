using System;
using System.Collections.Generic;

namespace RedStore.Models;

public partial class TbOffer
{
    public int OffersId { get; set; }

    public string? ImageName { get; set; }

    public int? CurrentState { get; set; }
}
