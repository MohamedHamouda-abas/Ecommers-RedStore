using System;
using System.Collections.Generic;

namespace RedStore.Models;

public partial class TbHeader
{
    public int HeaderId { get; set; }

    public string? ImageName { get; set; }

    public int CurrentState { get; set; }

    public string? Title { get; set; }

    public string? Paragraph { get; set; } 
}
