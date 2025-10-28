using VegMeatMarket.Database.AppDbContextModels;
using VegMeatMarket.Domain.Dtos;
using Microsoft.EntityFrameworkCore; // For AsNoTracking()

namespace VegMeatMarket.Domain.Features
{
    public class ProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public ProductResponseDto GetProducts(string? Category = null)
        {
            var list = _db.TblProducts
                .AsNoTracking()
                .Where(p => !p.IsDeleted &&
                            (string.IsNullOrEmpty(Category) || p.Category == Category))
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    Unit = p.Unit,
                    PricePerUnit = p.PricePerUnit,
                    StockQuantity = p.StockQuantity,
                    CreatedAt = p.CreatedAt,
                    CreatedBy = p.CreatedBy,
                    ModifiedAt = p.ModifiedAt,
                    ModifiedBy = p.ModifiedBy,
                    IsDeleted = p.IsDeleted
                })
                .ToList();

            return new ProductResponseDto
            {
                IsSuccess = true,
                Message = list.Any() ? "Products retrieved successfully." : "No products found.",
                Products = list
            };
        }

        public ProductResponseDto CreateProduct(ProductCreateDto dto, string createdBy)
        {
            var product = new TblProduct
            {
                ProductName = dto.ProductName,
                Category = dto.Category,
                Unit = dto.Unit,
                PricePerUnit = dto.PricePerUnit,
                StockQuantity = dto.StockQuantity,
                CreatedAt = DateTime.Now,
                CreatedBy = createdBy,
                IsDeleted = false
            };

            _db.TblProducts.Add(product);
            _db.SaveChanges();

            return new ProductResponseDto
            {
                IsSuccess = true,
                Message = "Product created successfully.",
                Products = new List<ProductDto> {
                    new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Category = product.Category,
                        Unit = product.Unit,
                        PricePerUnit = product.PricePerUnit,
                        StockQuantity = product.StockQuantity,
                        CreatedAt = product.CreatedAt,
                        CreatedBy = product.CreatedBy,
                        IsDeleted = product.IsDeleted
                    }
                }
            };
        }

        public ProductResponseDto UpdateProduct(int productId, ProductUpdateDto dto, string modifiedBy)
        {
            var product = _db.TblProducts.FirstOrDefault(p => p.ProductId == productId && !p.IsDeleted);

            if (product == null)
                return new ProductResponseDto { IsSuccess = false, Message = "Product not found." };

            product.ProductName = dto.ProductName ?? product.ProductName;
            product.Category = dto.Category ?? product.Category;
            product.Unit = dto.Unit ?? product.Unit;
            product.PricePerUnit = dto.PricePerUnit ?? product.PricePerUnit;
            product.StockQuantity = dto.StockQuantity ?? product.StockQuantity;
            product.ModifiedAt = DateTime.Now;
            product.ModifiedBy = modifiedBy;
            if (dto.IsDeleted.HasValue)
                product.IsDeleted = dto.IsDeleted.Value;


            _db.SaveChanges();

            return new ProductResponseDto
            {
                IsSuccess = true,
                Message = "Product updated successfully.",
                Products = new List<ProductDto> {
                    new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Category = product.Category,
                        Unit = product.Unit,
                        PricePerUnit = product.PricePerUnit,
                        StockQuantity = product.StockQuantity,
                        CreatedAt = product.CreatedAt,
                        CreatedBy = product.CreatedBy,
                        ModifiedAt = product.ModifiedAt,
                        ModifiedBy = product.ModifiedBy,
                        IsDeleted = product.IsDeleted
                    }
                }
            };
        }
        public ProductResponseDto DeleteProduct(int productId, string modifiedBy)
        {
            var product = _db.TblProducts.FirstOrDefault(p => p.ProductId == productId && !p.IsDeleted);

            if (product == null)
                return new ProductResponseDto { IsSuccess = false, Message = "Product not found." };

            product.IsDeleted = true;
            product.ModifiedAt = DateTime.Now;
            product.ModifiedBy = modifiedBy;

            _db.SaveChanges();

            return new ProductResponseDto
            {
                IsSuccess = true,
                Message = "Product deleted successfully.",
                Products = new List<ProductDto> {
                    new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        Category = product.Category,
                        Unit = product.Unit,
                        PricePerUnit = product.PricePerUnit,
                        StockQuantity = product.StockQuantity,
                        CreatedAt = product.CreatedAt,
                        CreatedBy = product.CreatedBy,
                        ModifiedAt = product.ModifiedAt,
                        ModifiedBy = product.ModifiedBy,
                        IsDeleted = product.IsDeleted
                    }
                }
            };
        }


        }
} 
