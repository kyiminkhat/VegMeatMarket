using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegMeatMarket.Domain.Dtos
{
    public class ProductDto
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
    }

    public class ProductCreateDto
    {
        public string ProductName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public decimal PricePerUnit { get; set; }
        public int StockQuantity { get; set; }
    }

    public class ProductUpdateDto
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public string? Unit { get; set; }
        public decimal? PricePerUnit { get; set; }
        public int? StockQuantity { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }


    public class ProductResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
        public List<ProductDto>? Products { get; set; }
    }

}
