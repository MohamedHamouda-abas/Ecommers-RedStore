using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedStore.Models;

public partial class Tbtestimonial
{
	[ValidateNever]
	public int TestimonialsId { get; set; }

    public string? CustmerName { get; set; }

	[ValidateNever]
	public string? ImageName { get; set; }

    public string? Comment { get; set; }

    public string? Rating { get; set; }

    public int? CurrentState { get; set; }
}
