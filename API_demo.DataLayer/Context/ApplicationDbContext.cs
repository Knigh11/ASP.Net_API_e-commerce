using API_demo.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace API_demo.DataLayers.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Shipper> Shippers { get; set; } = null!;
        public DbSet<ProductAttribute> ProductAttribute { get; set; } = null!;
        public DbSet<ProductPhoto> ProductPhotos { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasKey(p => p.ProvinceName); // Đánh dấu Province không có khóa chính
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderID, od.ProductID }); // Định nghĩa khóa chính tổng hợp
            modelBuilder.Entity<ProductAttribute>().HasKey(p => p.AttributeID);
            modelBuilder.Entity<ProductPhoto>().HasKey(p => p.PhotoId);

        }
    }
}