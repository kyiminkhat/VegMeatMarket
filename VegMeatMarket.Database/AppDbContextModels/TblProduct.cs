using System;
using System.Collections.Generic;

namespace VegMeatMarket.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal PricePerUnit { get; set; }

    public int StockQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TblPurchaseDetail> TblPurchaseDetails { get; set; } = new List<TblPurchaseDetail>();

    public virtual ICollection<TblSaleDetail> TblSaleDetails { get; set; } = new List<TblSaleDetail>();
}
