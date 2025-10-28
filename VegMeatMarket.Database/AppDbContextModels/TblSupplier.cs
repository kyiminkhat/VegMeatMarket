using System;
using System.Collections.Generic;

namespace VegMeatMarket.Database.AppDbContextModels;

public partial class TblSupplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TblPurchase> TblPurchases { get; set; } = new List<TblPurchase>();
}
