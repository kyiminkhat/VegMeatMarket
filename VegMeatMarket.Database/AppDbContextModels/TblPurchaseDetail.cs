using System;
using System.Collections.Generic;

namespace VegMeatMarket.Database.AppDbContextModels;

public partial class TblPurchaseDetail
{
    public int PurchaseDetailId { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal CostPerUnit { get; set; }

    public decimal? Subtotal { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TblProduct Product { get; set; } = null!;

    public virtual TblPurchase Purchase { get; set; } = null!;
}
