using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace day4.Models;

public partial class Product
{
    internal object?[]? id;

    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    [Required]
    //[Range(0, 200, ErrorMessage = "Price between 0 and 200")]
    //[BindNever]
    public int? Price { get; set; }

    public string? Image { get; set; }
}
