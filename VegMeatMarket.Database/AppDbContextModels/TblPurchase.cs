using System;
using System.Collections.Generic;

namespace VegMeatMarket.Database.AppDbContextModels;

public partial class TblPurchase
{
    public int PurchaseId { get; set; }

    public int SupplierId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public decimal TotalCost { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TblSupplier Supplier { get; set; } = null!;

    public virtual ICollection<TblPurchaseDetail> TblPurchaseDetails { get; set; } = new List<TblPurchaseDetail>();
}
