using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthbayWebAPI.Models;

public partial class ProductList
{
    [Key]
    public Guid? ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? ProductPrice { get; set; }

    public int? ProductQuanity { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? Datecreated { get; set; }
}
